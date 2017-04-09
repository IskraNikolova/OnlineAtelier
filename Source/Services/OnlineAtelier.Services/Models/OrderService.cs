namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using Logic;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orders;

        public OrderService(IRepository<Order> orders)
        {
            this.orders = orders;
        }

        public void AddOrder(OrderBindingModel model, string authorId,
            Appearance appearance,
            Category category)
        {
            var order = Mapper.Map<OrderBindingModel, Order>(model);
            order.AppearanceId = appearance.Id;
            order.CategoryId = category.Id;
            order.ApplicationUserId = authorId;

            this.orders.Add(order);
            this.orders.SaveChanges();
        }

        public AddOrderVm GetViewModel(OrderBindingModel model,
            IEnumerable<string> categories,
            IEnumerable<string> appearances)
        {
            var orderViewModel = Mapper.Map<OrderBindingModel, AddOrderVm>(model);

            orderViewModel.Categories = GetListItem.GetSelectListItems(categories);
            orderViewModel.Appearances = GetListItem.GetSelectListItems(appearances);

            return orderViewModel;
        }

        public IEnumerable<DisplayOrderVm> GetOrders(string id)
        {
            var profileOrdersViewModel = this.orders.All()
                .Where(o => o.ApplicationUserId == id)
                .Project()
                .To<DisplayOrderVm>()
                .OrderByDescending(o => o.CreatedOn)
                .ToList();

            return profileOrdersViewModel;
        }

        public DetailsOrderVm GetDetails(int id)
        {
            var order = this.orders
                .All()
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            var model = Mapper.Map<Order, DetailsOrderVm>(order);
            model.CategoryName = order.Category.Name;

            return model;
        }
    }
}