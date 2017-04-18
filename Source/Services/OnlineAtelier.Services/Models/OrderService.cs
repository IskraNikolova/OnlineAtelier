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
        private readonly IRepository<Figure> figures;

        public OrderService(IRepository<Order> orders, IRepository<Figure> figures)
        {
            this.orders = orders;
            this.figures = figures;
        }

        public void AddOrder(OrderBindingModel model, 
                            string authorId,
                            Appearance appearance,
                            Category category)
        {
            var order = Mapper.Map<OrderBindingModel, Order>(model);
            order.FinalPrice = appearance.Price;
            order.AppearanceId = appearance.Id;
            order.CategoryId = category.Id;
            order.ApplicationUserId = authorId;

            this.orders.Add(order);
            this.orders.SaveChanges();
        }

        public AddOrderVm GetAddOrderVm(OrderBindingModel model,
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

        public IEnumerable<DisplayOrderVm> GetAllNewOrders()
        {
            var profileOrdersViewModel = this.orders
                .All()
                .Where(o => !o.IsExecuted)
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

            var model = Mapper.Map<Order, DetailsOrderVm>(order);
            model.FiguresNames = order.Figures.Select(f => f.Name).ToList();

            foreach (var figure in order.Figures)
            {
                if (!model.ContentOfOrder.ContainsKey(figure.Name))
                {
                    model.ContentOfOrder[figure.Name] = 0;
                }

                model.ContentOfOrder[figure.Name]++;
            }
           
            model.CategoryName = order.Category.Name;

            return model;
        }

        public EditOrderVm GetEditViewModel(int? id)
        {
            var entity = this.orders.GetById((int)id);
            var vModel = Mapper.Map<Order, EditOrderVm>(entity);
            return vModel;
        }

        public DesignOrderVm GetDesignOrderVm(int? id)
        {
            var entity = this.orders.GetById((int)id);

            var vModel = Mapper.Map<Order, DesignOrderVm>(entity);
            vModel.AllForms = entity.Figures.Select(f => f.Name);
         
            return vModel;
        }

        public void Edit(EditOrderBm model)
        {
            var entity = this.orders.GetById(model.Id);

            entity.ColorOfBox = model.ColorOfBox;
            entity.FinalPrice = model.FinalPrice;
            entity.IsАccepted = model.IsАccepted;
            entity.IsExecuted = model.IsExecuted;
            entity.ShippingAddress = model.ShippingAddress;
            entity.TextOfBox = model.TextOfBox;
            entity.TextOfCookies = model.TextOfCookies;
      
            this.orders.Update(entity);
            this.orders.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.orders.GetById(id);
            this.orders.Delete(entity);
            this.orders.SaveChanges();
        }

        public void AddFigures(DesignOrderBm bm)
        {
            var order = this.orders
                .All()
                .FirstOrDefault(o => o.Id == bm.Id);

            if (order.Appearance.CookiesCount > order.Figures.Count)
            {
                order.Figures.Add(new Figure()
                {
                    Name = bm.FiguresName
                });


                this.orders.Update(order);
                this.orders.SaveChanges();

            }//todo write message can not add figure or do change of other
        }

        public EditOrderDateVm GetEditDateViewModel(int? id)
        {
            var entity = this.orders.GetById((int)id);
            var vModel = Mapper.Map<Order, EditOrderDateVm>(entity);
            return vModel;
        }

        public void EditDate(EditOrderDateBm model)
        {
            var entity = this.orders.GetById(model.Id);
            entity.DateOfDecision = model.DateOfDecision;

            this.orders.Update(entity);
            this.orders.SaveChanges();
        }
    }
}