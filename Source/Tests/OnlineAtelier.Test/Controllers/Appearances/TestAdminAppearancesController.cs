namespace OnlineAtelier.Test.Controllers.Appearances
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
    using Web.Areas.Admin.Controllers;
    using Web.Controllers;
    using Web.Models.BindingModels.Appearance;
    using Web.Models.BindingModels.Comments;

    [TestClass]
    public class TestAdminAppearancesController
    {
        private AdminAppearanceController _controller;
        private IAppearanceService _service;
        private IRepository<Appearance> _repository;
        private List<Appearance> appearances;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<AppearanceCreateBm, Appearance>();
            });
        }
        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.appearances = new List<Appearance>()
            {
                new Appearance()
                {
                    Id = 1,
                    Name = "Кутия от 32бр.",
                    Price = 234.09m
                },
                new Appearance()
                {
                    Id = 21,
                    Name = "Кутия от 39бр.",
                    Price = 284.09m
                }
            };

            this._repository = new FakeDeletableRepository<Appearance>();

            foreach (var appearance in this.appearances)
            {
                this._repository.Set.Add(appearance);
            }

            this._service = new AppearancesService(this._repository);
            this._controller = new AdminAppearanceController(this._service);
        }

        [TestMethod]
        public void CreateAppearanceGet_ShouldReturnView()
        {
            this._controller.WithCallTo(appearnceController => appearnceController.Create())
                .ShouldRenderView("Create");
        }
    }
}
