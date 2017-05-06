using OnlineAtelier.Web.Models.BindingModels.Order;

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
                    Text = "Hello ",
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
                this._repository.Set.Add(comment);
            }

            this._service = new CommentService(this._repository);
            this._controller = new CommentOrderController(this._service);
        }

        [TestMethod]
        public void AddCommentGet_ShouldReturnRedirectToAction()
        {
            this._controller.WithCallTo(orderCommentController => orderCommentController.AddComment(22))
                .ShouldRenderPartialView("_AddCommentPartial");
        }

        [TestMethod]
        public void DeleteCommentGet_ShouldReturnRedirectToAction()
        {
            this._controller.WithCallTo(orderCommentController => orderCommentController.Delete())
                .ShouldRenderView("Delete");
        }
    }
}