namespace OnlineAtelier.Test.Controllers.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using AutoMapper;
    using Data.Common.Repository;
    using Data.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Models;
    using Services.Contracts;
    using Services.Models;
    using TestStack.FluentMVCTesting;
    using Web.Areas.Admin.Controllers;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    [TestClass]
    public class TestAdminOrdersController
    {
        private AdminOrdersController _controller;
        private IOrderService _service;
        private IFigureService _figureService;
        private IRepository<Order> _repository;
        private IRepository<Figure> _figuresRepository;
        private IRepository<Appearance> _arepository;
        private IRepository<Category> _carepository;
        private List<Order> orders;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<EditOrderBm, Order>();
                expression.CreateMap<EditOrderDateBm, Order>();
                expression.CreateMap<DesignOrderBm, Order>();
                expression.CreateMap<Order, DesignOrderVm>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    ApplicationUserId = "a2f23d5c-f9ef-41c0-95d4-52934b9d9dde"                    
                },
                new Order()
                {
                    Id = 21,
                    ApplicationUserId = "a2f23d5c-f9ef-41c0-95d4-52934b9d9dde"

                }
            };

            this._repository = new FakeDeletableRepository<Order>();
            this._figuresRepository = new FakeDeletableRepository<Figure>();
            this._arepository = new FakeDeletableRepository<Appearance>();
            this._carepository = new FakeDeletableRepository<Category>();

            foreach (var order in this.orders)
            {
                order.Appearance = new Appearance()
                {
                    Name = "Кутия от 100бр",
                    Price = 2990.23m,
                    CookiesCount = 10
                };

                this._repository.Add(order);
            }

            this._service = new OrderService(this._repository, this._arepository, this._carepository);
            this._figureService = new FigureService(this._figuresRepository);
            this._controller = new AdminOrdersController(this._service, this._figureService);
        }

        [TestMethod]
        public void EditOrderPost_ShouldEditAndReturnRedirectToAction()
        {
            var orderBm = new EditOrderBm()
            {
                Id = 1,
                TextOfCookies = "нещо",
                TextOfBox = "нещо",
                ColorOfBox = "нещо",
                FinalPrice = 78.0m
            };

            this._controller.WithCallTo(order => order.Edit(orderBm))
                .ShouldRedirectTo<AdminOrdersController>(c2 => c2.Index());

            var orderEntity = this._repository.Set.FirstOrDefault(p => p.Id == orderBm.Id);

            Assert.AreEqual(orderEntity.Id, 1);
            Assert.AreEqual(orderEntity.TextOfCookies, "нещо");
            Assert.AreEqual(orderEntity.TextOfBox, "нещо");
            Assert.AreEqual(orderEntity.ColorOfBox, "нещо");
            Assert.AreEqual(orderEntity.FinalPrice, 78.0m);
        }

        [TestMethod]
        public void EditDateOrderPost_ShouldEditDateAndReturnRedirectToAction()
        {
            var orderBm = new EditOrderDateBm()
            {
                Id = 1,
                DateOfDecision = new DateTime(2017, 03, 02)
            };

            this._controller.WithCallTo(order => order.EditDate(orderBm))
                .ShouldRedirectTo<AdminOrdersController>(c2 => c2.Index());

            var orderEntity = this._repository.Set.FirstOrDefault(p => p.Id == orderBm.Id);

            Assert.AreEqual(orderEntity.Id, 1);
            Assert.AreEqual(orderEntity.DateOfDecision, new DateTime(2017, 03, 02));
        }

        [TestMethod]
        public void DeleteConfirmedPost_ShouldDeleteAndReturnRedirectToAction()
        {
            this._controller.WithCallTo(order=> order.DeleteConfirmed(1))
                  .ShouldRedirectTo<AdminOrdersController>(c2 => c2.Index());

            Assert.AreEqual(this._repository.Set.Count, 1);
        }

        [TestMethod]
        public void DeleteGet_ShouldReturnThisView()
        {
            this._controller.WithCallTo(order => order.Delete())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void DesignGetWithNullId_ShouldReturnBadRequest()
        {
            int? id = null;
            this._controller.WithCallTo(order => order.DesignIt(id))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void DesignGetWithModelNull_ShouldReturnNotFound()
        {
            this._controller.WithCallTo(order => order.DesignIt(2))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void DesignPost_ShouldAddFigureAndReturnThisView()
        {
            var model = new DesignOrderBm()
            {
                Id = 1,
                FiguresName = "Пеперуда"
            };

            this._controller.WithCallTo(order => order.DesignIt(model))
                .ShouldRenderDefaultView()
               .WithModel<DesignOrderVm>(m => m.Id = 1);

            var orderEntity = this._repository.Set.FirstOrDefault(o => o.Id == model.Id);
            if (orderEntity != null)
                Assert.AreEqual(orderEntity.Figures.Count, 1);
        }
    }
}