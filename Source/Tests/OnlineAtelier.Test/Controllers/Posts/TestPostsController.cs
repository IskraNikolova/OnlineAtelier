namespace OnlineAtelier.Test.Controllers.Posts
{
    using System.Collections.Generic;
    using System.Net;
    using AutoMapper;
    using Data.Common.Repository;
    using Data.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Models;
    using Services.Contracts;
    using Services.Models;
    using TestStack.FluentMVCTesting;

    using Web.Controllers;
    using Web.Models.ViewModels.Posts;

    [TestClass]
    public class TestPostsController
    {
        private PostsController _controller;
        private IPostService _service;
        private IRepository<Post> _repository;
        private List<Post> posts;


        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Post, DetailsPostsVModel>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "Title",
                    Content = "Content",
                    CategoryId = 1
                },
                new Post()
                {
                    Id = 21,
                    Title = "Title",
                    Content = "Content",
                    CategoryId = 1
                }
            };

            this._repository = new FakeDeletableRepository<Post>();

            foreach (var post in this.posts)
            {
                this._repository.Set.Add(post);
            }

            this._service = new PostService(this._repository);
            this._controller = new PostsController(this._service);
        }

        [TestMethod]
        public void DetailsWithIdNull_ShouldReturnBadRequest()
        {
            int? id = null;
            this._controller.WithCallTo(postsController => postsController.Details(id))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void DetailsWithPostVmNull_ShouldReturnNotFound()
        {
            this._controller.WithCallTo(postsController => postsController.Details(2))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }
    }
}
