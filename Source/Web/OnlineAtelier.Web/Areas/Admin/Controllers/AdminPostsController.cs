namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using Logic;
    using Models.BindingModels.Posts;
    using Models.ViewModels.AdminArea.Posts;
    using OnlineAtelier.Models.Models;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminPostsController : Controller
    {
        private readonly IPostService service;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;

        public AdminPostsController(IPostService service,
            ICategoryService categoryService,
            IUserService userServise)
        {
            this.service = service;
            this.categoryService = categoryService;
            this.userService = userServise;
        }

        [HttpGet]
        [Route("AdminPosts/Index")]
        public ActionResult Index()
        {
            var posts = this.service.All();
            return this.View(posts);
        }

        [HttpGet]
        [Route("AdminPosts/Create")]
        public ActionResult Create()
        {
            var model = this.GetCreatePublicationVm();
            return this.View(model);
        }

        [HttpPost]
        [Route("AdminPosts/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostBm post)
        {
            if (this.ModelState.IsValid)
            {
                var category = this.categoryService.GetCategory(post.CategoryName);
                this.service.AddPublication(post, category);
                return this.RedirectToAction("Index");
            }

            return this.View(this.GetCreatePublicationVm());
        }

        [HttpGet]
        [Route("AdminPosts/Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var publication = this.service.GetViewModel(id);
            if (publication == null)
            {
                return this.HttpNotFound();
            }

            return this.View(publication);
        }

        [HttpPost]
        [Route("AdminPosts/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostBm post)
        {
            if (this.ModelState.IsValid)
            {
                this.service.Edit(post);
                return this.RedirectToAction("Index");
            }

            return this.View(post);
        }

        [HttpGet]
        [Route("AdminPosts/Delete")]
        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost, ActionName("Delete")]
        [Route("AdminPosts/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.Delete(id);
            return this.RedirectToAction("Index", "Home");
        }

        private CreatePostsVm GetCreatePublicationVm()
        {
            var model = new CreatePostsVm()
            {
                Categories = GetListItem.GetSelectListItems(this.categoryService.GetAllCategories()),
            };

            return model;
        }
    }
}