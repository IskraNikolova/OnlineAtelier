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
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

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

        public void AddOrder(AddOrderVm model, string authorId, byte[] imageData)
        {
            var user = this.users.All()
                .FirstOrDefault(u => u.Id == authorId);
            this.users.Detach(user);

            var appearance = this.appearances.All()
                .FirstOrDefault(a => a.Name == model.AppearanceName);

            var order = Mapper.Map<AddOrderVm, Order>(model);
            order.Appearance = appearance;
            order.ApplicationUser = user;

            this.orders.Add(order);
            this.orders.SaveChanges();
        }

        public AddOrderVm GetViewModel(OrderBindingModel model)
        {
            var orderViewModel = Mapper.Map<OrderBindingModel, AddOrderVm>(model);

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
            var selectList = new List<SelectListItem>();
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

        public IEnumerable<DisplayOrderVm> GetOrders(string id)
        {
            var profileOrdersViewModel = this.orders.All()
                .Where(o => o.ApplicationUser.Id == id)
                .Project()
                .To<DisplayOrderVm>();

            return profileOrdersViewModel;
        }

        public DetailsOrderVm GetDetails(int id)
        {
            var order = this.orders.All()
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            var model = Mapper.Map<Order, DetailsOrderVm>(order);

            return model;
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
    }
}