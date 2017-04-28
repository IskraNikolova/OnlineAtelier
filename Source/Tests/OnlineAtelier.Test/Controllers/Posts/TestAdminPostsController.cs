namespace OnlineAtelier.Test.Controllers.Posts
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
    using Web.Models.BindingModels.Posts;
    using Web.Models.ViewModels.AdminArea.Posts;

    [TestClass]
    public class TestAdminPostsController
    {
        private AdminPostsController _controller;
        private IPostService _service;
        private ICategoryService _categoryService;
        private IRepository<Post> _repository;
        private IRepository<Category> _carepository;
        private List<Post> posts;
        private List<Category> categories;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Post, CreatePostsVm>();
                expression.CreateMap<PostBm, Post>();
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

            this.categories = new List<Category>()
           {
               new Category()
               {
                   Id = 1,
                   Name = "Великден"
               }
           };

            this._repository = new FakeDeletableRepository<Post>();
            this._carepository = new FakeDeletableRepository<Category>();

            foreach (var post in this.posts)
            {
                this._repository.Set.Add(post);
            }

            foreach (var category in this.categories)
            {
                this._carepository.Set.Add(category);
            }

            this._service = new PostService(this._repository);
            this._categoryService = new CategoryService(this._carepository);
            this._controller = new AdminPostsController(this._service, this._categoryService);
        }

        [TestMethod]
        public void EditPostWithNullId_ShouldReturnBadRequest()
        {
            int? id = null;
            this._controller.WithCallTo(adminPostsController => adminPostsController.Edit(id))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void EditGet_ShouldReturnView()
        {
            int? id = 1;
            this._controller.WithCallTo(adminPostsController => adminPostsController.Edit(id))
               .ShouldRenderView("Edit");
        }

        [TestMethod]
        public void EditPost_ShouldEditAndRedirectToAll()
        {
            var postBm = new PostBm()
            {
                Id = 1,
                Title = "нещо ново"
            };

            this._controller.WithCallTo(adminPostsController => adminPostsController.Edit(postBm))
               .ShouldRedirectTo<AdminPostsController>(c2 => c2.All());

             var post = this._repository.Set.FirstOrDefault(p => p.Id == postBm.Id);

             Assert.AreEqual(post.Id, 1);
             Assert.AreEqual(post.Title, "нещо ново");
        }

        [TestMethod]
        public void DeleteGet_ShouldReturnView()
        {
            this._controller.WithCallTo(adminPostsController => adminPostsController.Delete())
                .ShouldRenderView("Delete");
        }

        [TestMethod]
        public void DeletePost_ShouldDeleteOnePostAndRedirectToAll()
        {
            this._controller.WithCallTo(adminPostsController => adminPostsController.DeleteConfirmed(1))
                .ShouldRedirectTo<AdminPostsController>(c2 => c2.All());

            Assert.AreEqual(this._repository.Set.Count, 1);
        }

        [TestMethod]
        public void CreateGet_ShouldAddedOnePostAndReturnView()
        {
            this._controller.WithCallTo(adminPostsController => adminPostsController.Create())
                .ShouldRenderView("Create");
        }

        [TestMethod]
        public void CreatePost_ShouldReturnViewAndAddPost()
        {
            var bm = new PostBm()
            {
                CategoryName = "Великден"
            };

            this._controller.WithCallTo(adminPostsController => adminPostsController.Create(bm))
               .ShouldRedirectTo<AdminPostsController>(c2 => c2.All());

            Assert.AreEqual(this._repository.Set.Count, 3);
        }
    }
}