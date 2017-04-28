namespace OnlineAtelier.Test.Controllers.Users
{
    using System.Collections.Generic;
    using System.Net;
    using AutoMapper;
    using Data.Common.Repository;
    using Data.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Models;
    using Models.Models.Comments;
    using Services.Contracts;
    using Services.Models;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Web.Models.BindingModels.Comments;
    using Web.Models.BindingModels.Users;
    using Web.Models.ViewModels.Comments;
    using Web.Models.ViewModels.Users;

    [TestClass]
    public class TestUsersController
    {

        private UsersController _controller;
        private IUserService _service;
        private IRepository<ApplicationUser> _repository;
        private List<ApplicationUser> comments;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<ApplicationUser, ProfileViewModel>();
                expression.CreateMap<ApplicationUser, EditUserVm>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.comments = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "10386b6e-882a-48a6-88a8-c000ede8ccea",
                    FirstName = "Nona",
                    LastName = "Mihaelova"
                },
                new ApplicationUser()
                {
                    Id = "99986b6e-702a-48a6-88a8-c000ede8ccea",
                    FirstName = "Opel",
                    LastName = "Kostadinow"
                }
            };

            this._repository = new FakeDeletableApplicationUserRepository<ApplicationUser>();

            foreach (var comment in this.comments)
            {
                this._repository.Set.Add(comment);
            }

            this._service = new UserService(this._repository);
            this._controller = new UsersController(this._service);
        }

        [TestMethod]
        public void ProfilePage_ShouldReturnView()
        {
            string id = "99986b6e-702a-48a6-88a8-c000ede8ccea";

            this._controller.WithCallTo(userController => userController.ProfilePage(id))
                .ShouldRenderView("ProfilePage");
        }

        [TestMethod]
        public void EditGetWithNullId_ShouldReturnBadRequest()
        {
            string id = null;
            this._controller.WithCallTo(userController => userController.Edit(id))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void EditGet_ShouldReturnBadRequest()
        {
            string id = "99986b6e-702a-48a6-88a8-c000ede8ccea";
            this._controller.WithCallTo(userController => userController.Edit(id))
                .ShouldRenderView("Edit");
        }
    }
}
