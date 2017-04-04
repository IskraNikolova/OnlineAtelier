namespace OnlineAtelier.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models;
    using Web.Models.BindingModels;
    using Web.Models.ViewModels.Order;
    using Web.Models.ViewModels.ProfilePage;

    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orders;
        private readonly IRepository<Category> categories;
        private readonly IRepository<Appearance> appearances;
        private readonly IRepository<ApplicationUser> users;

        public OrderService(IRepository<Order> orders,
            IRepository<Category> categories,
            IRepository<Appearance> appearances,
            IRepository<ApplicationUser> users)
        {
            this.orders = orders;
            this.categories = categories;
            this.appearances = appearances;
            this.users = users;
        }

        public void AddOrder(OrderViewModel model, string authorId, byte[] imageData)
        {
            var user = this.users.All()
                .FirstOrDefault(u => u.Id == authorId);

            this.users.Detach(user);

            var appearance = this.appearances.All()
                .FirstOrDefault(a => a.Name == model.Appearance);

            IEnumerable<UserPicture> pictures = new List<UserPicture>();

            pictures.ToList().Add(
                new UserPicture()
                {
                    UserPictures = imageData
                });


            var order = new Order()
            {
                Id = model.Id,
                Category = model.Category,
                Details = model.Details,
                DateOfDecision = model.DateOfDecision,
                ShippingAddress = model.ShippingAddress,
                ColorOfBox = model.ColorOfBox,
                TextOfBox = model.TextOfBox,
                TextOfCookies = model.TextOfCookies,
                Appearance = appearance,
                ApplicationUser = user,
                UserPictures = pictures
            };

            this.orders.Add(order);
            this.orders.SaveChanges();
        }

        public OrderViewModel GetViewModel(OrderBindingModel model)
        {

            var viewModel = new OrderViewModel()
            {
                Category = model.Category,
                Details = model.Details,
                DateOfDecision = model.DateOfDecision,
                ShippingAddress = model.ShippingAddress,
                ColorOfBox = model.ColorOfBox,
                TextOfBox = model.TextOfBox,
                TextOfCookies = model.TextOfCookies,
                Appearance = model.Appearance,
                Categories = this.GetSelectListItems(this.GetAllCategories()),
                Appearances = this.GetSelectListItems(this.GetAllAppearances())

            };

            return viewModel;
        }

        public IEnumerable<string> GetAllCategories()
        {
            var allCategories = this.categories
                .All()
                .Select(c => c.CategoryName)
                .ToList();

            return allCategories;
        }

        public IEnumerable<string> GetAllAppearances()
        {
            var allAppearances = this.appearances
                .All()
                .Select(a => a.Name)
                .ToList();

            return allAppearances;
        }

        public IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="Category">Category</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        public IEnumerable<ProfileOrdersViewModel> GetOrders(string id)
        {
            var currentOrders = this.orders.All()
                .Where(o => o.ApplicationUser.Id == id)
                .ToList();

            var ordersModel = new List<ProfileOrdersViewModel>();
            foreach (var item in currentOrders)
            {
                var order = new ProfileOrdersViewModel()
                {
                    Id = item.Id,
                    Details = item.Details,
                    Category = item.Category,
                    AppearanceName = item.Appearance.Name,
                    AppearancePrice = item.Appearance.Price,
                    CreatedOn = item.CreatedOn,
                };

                ordersModel.Add(order);
            }

            return ordersModel;
        }
    }
}