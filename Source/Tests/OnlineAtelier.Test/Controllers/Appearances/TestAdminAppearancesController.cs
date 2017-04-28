namespace OnlineAtelier.Test.Controllers.Appearances
{
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
    using Web.Controllers;
    using Web.Models.BindingModels.Appearance;
    using Web.Models.ViewModels.AdminArea.Appearance;

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
                expression.CreateMap<Appearance, AppearanceEditVm>();
                expression.CreateMap<AppearanceEditBm, Appearance>();
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

        [TestMethod]
        public void CreateAppearancePost_ShouldAddAppearanceAndRedirect()
        {
            AppearanceCreateBm bm = new AppearanceCreateBm()
            {
                Name = "Кути, от 555бр.",
                Price = 234.8m,
                CookiesCount = 555
            };

            this._controller.WithCallTo(appearnceController => appearnceController.Create(bm))
               .ShouldRedirectTo<AppearanceController>(c2 => c2.PriceList());

            Assert.AreEqual(this._repository.Set.Count, 3);
        }

        [TestMethod]
        public void EditWithNullIdGet_ShouldReturnBadRequest()
        {
            int? id = null;
            this._controller.WithCallTo(appContr => appContr.Edit(id))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void EditWithNullModelGet_ShouldReturnNotFound()
        {
            this._controller.WithCallTo(appContr => appContr.Edit(67))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void EditGet_ShouldReturnView()
        {
            this._controller.WithCallTo(appContr => appContr.Edit(1))
                .ShouldRenderView("Edit");
        }

        [TestMethod]
        public void EditPost_ShouldRedirect()
        {
            var bm = new AppearanceEditBm()
            {
                Id = 1,
                Name = "Kutiq",
                Price = 21.0m,
            };

            this._controller.WithCallTo(appContr => appContr.Edit(bm))
                .ShouldRedirectTo<AppearanceController>(c2 => c2.PriceList());
            var entity = this._repository.Set.FirstOrDefault(e => e.Id == bm.Id);

            if (entity == null) return;
            Assert.AreEqual(entity.Name, "Kutiq");
            Assert.AreEqual(entity.Price, 21.0m);
        }

        [TestMethod]
        public void DeleteGet_ShouldReturnView()
        {
            this._controller.WithCallTo(appContr => appContr.Delete())
                .ShouldRenderView("Delete");
        }

        [TestMethod]
        public void DeletePost_ShouldDeleteAndredirect()
        {
            this._controller.WithCallTo(appContr => appContr.DeleteConfirmed(1))
                     .ShouldRedirectTo<AppearanceController>(c2 => c2.PriceList());

            Assert.AreEqual(this._repository.Set.Count, 1);
        }
    }
}
