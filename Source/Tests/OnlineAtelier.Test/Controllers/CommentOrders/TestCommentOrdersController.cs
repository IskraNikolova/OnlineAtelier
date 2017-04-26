namespace OnlineAtelier.Test.Controllers.CommentOrders
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Common.Repository;
    using Data.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Models.Comments;
    using Services.Contracts;
    using Services.Models;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Web.Models.BindingModels.Comments;
    using Web.Models.ViewModels.Comments;


    [TestClass]
    public class TestCommentOrdersController
    {
        private CommentOrderController _controller;
        private ICommentService _service;
        private IRepository<OrderComment> _repository;
        private List<OrderComment> comments;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<OrderCommentBm, OrderComment>();
                expression.CreateMap<OrderComment, OrderCommentViewModel>();
            });
        }


        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.comments = new List<OrderComment>()
            {
                new OrderComment()
                {
                    Id = 1,
                    Text = "Hello",
                    OrderId = 1,
                    ApplicationUserId = "a2f23d5c-f9ef-41c0-95d4-52934b9d9dde"

                },
                new OrderComment()
                {
                    Id = 21,
                    Text = "Hello",
                    OrderId = 22,
                    ApplicationUserId = "a2f23d5c-f9ef-41c0-95d4-52934b9d9dde"

                }
            };

            this._repository = new FakeDeletableRepository<OrderComment>();

            foreach (var comment in this.comments)
            {
                this._repository.Add(comment);
            }

            this._service = new CommentService(this._repository);
            this._controller = new CommentOrderController(this._service);
        }

        [TestMethod]
        public void AddComment_ShouldReturnRedirectToAction()
        {
            var bm = new OrderCommentBm()
            {
                Text = "Hi",
                OrderId = 22
            };

            this._controller.WithCallTo(orderCommentController => orderCommentController.AddComment(bm, 22))
                  .ShouldRedirectTo<UsersController>(c2 => c2.ProfilePage("a2f23d5c-f9ef-41c0-95d4-52934b9d9dde"));
        }

        //[TestMethod]
        //public void GetComments_ShouldReturnPartialView()
        //{
        //    this._controller.WithCallTo(orderCommentController => orderCommentController.GetComments(22))
        //          .ShouldRenderPartialView("_ViewCommentsPartial");
        //}

        [TestMethod]
        public void DeleteComment_ShouldReturnRedirectToAction()
        {

            this._controller.WithCallTo(orderCommentController => orderCommentController.DeleteConfirmed(22))
                  .ShouldRedirectTo<UsersController>(c2 => c2.ProfilePage("a2f23d5c-f9ef-41c0-95d4-52934b9d9dde"));
        }
    }
}
