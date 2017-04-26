namespace OnlineAtelier.Test.Controllers.Orders
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Common.Repository;
    using Data.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Models;
    using Services.Contracts;
    using Services.Models;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Web.Models.BindingModels.Order;

    [TestClass]
    public class TestOrderController
    {
        private OrderController _controller;
        private IOrderService _service;
        private ICategoryService _categoryService;
        private IAppearanceService _appearanceServices;
        private IRepository<Order> _repository;
        private IRepository<Appearance> _arepository;
        private IRepository<Category> _carepository;
        private List<Order> orders;
        private List<Category> categories;
        private List<Appearance> appearances;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<OrderBindingModel, Order>();
                //expression.CreateMap<OrderComment, OrderCommentViewModel>();
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

            this.appearances = new List<Appearance>()
            {
                new Appearance()
                {
                    Id = 1,
                    CookiesCount = 3,
                    IsBoxOfNormalSize = true,
                    Name = "Кутия от 3бр.",
                    Price = 12.0m
                },
                new Appearance()
                {
                    Id = 2,
                    CookiesCount = 6,
                    IsBoxOfNormalSize = true,
                    Name = "Кутия от 6бр.",
                    Price = 24.0m
                }
            };

            this.categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Великден",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Коледа",
                }
            };

            this._repository = new FakeDeletableRepository<Order>();
            this._arepository = new FakeDeletableRepository<Appearance>();
            this._carepository = new FakeDeletableRepository<Category>();

            foreach (var order in this.orders)
            {
                this._repository.Add(order);
            }

            this._service = new OrderService(this._repository, this._arepository, this._carepository);
            this._appearanceServices = new AppearancesService(this._arepository);
            this._categoryService = new CategoryService(this._carepository);
            this._controller = new OrderController(this._service, this._categoryService, this._appearanceServices);
        }

        [TestMethod]
        public void AddOrder_ShouldReturnRedirectToAction()
        {
            var bm = new OrderBindingModel()
            {
                UserId = "a2f23d5c-f9ef-41c0-95d4-52934b9d9dde",
                AppearanceName = "Кутия от 6бр.",
                CategoryName = "Великден"
            };

            this._controller.WithCallTo(order => order.Add(bm))
                .ShouldRedirectTo<UsersController>(c2 => c2.ProfilePage("a2f23d5c-f9ef-41c0-95d4-52934b9d9dde"));
        }
    }
}