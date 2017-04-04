namespace OnlineAtelier.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
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
                .FirstOrDefault(a => a.Name == model.AppearanceName);

            var pictures = TakeUserPictures(imageData);

            var order = Mapper.Map<OrderViewModel, Order>(model);
            order.Appearance = appearance;
            order.ApplicationUser = user;
            order.UserPictures = pictures;

            this.orders.Add(order);
            this.orders.SaveChanges();
        }

        private static IEnumerable<UserPicture> TakeUserPictures(byte[] imageData)
        {
            IEnumerable<UserPicture> pictures = new List<UserPicture>();

            pictures.ToList().Add(new UserPicture()
            {
                UserPictures = imageData
            });
            return pictures;
        }

        public OrderViewModel GetViewModel(OrderBindingModel model)
        {
            var orderViewModel = Mapper.Map<OrderBindingModel, OrderViewModel>(model);

            orderViewModel.Categories = this.GetSelectListItems(this.GetAllCategories());
            orderViewModel.Appearances = this.GetSelectListItems(this.GetAllAppearances());

            return orderViewModel;
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
            var profileOrdersViewModel = this.orders.All()
                .Where(o => o.ApplicationUser.Id == id)
                .Project()
                .To<ProfileOrdersViewModel>();

            return profileOrdersViewModel;
        }
    }
}