namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Logic;
    using Models.BindingModels.Posts;
    using Models.ViewModels.AdminArea.Posts;
    using Services.Contracts;


    public class AdminPostsController : BaseAdminController
    {
        private readonly IPostService service;
        private readonly ICategoryService categoryService;

        public AdminPostsController(IPostService service,
            ICategoryService categoryService)
        {
            this.service = service;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("AdminPosts/All")]
        public ActionResult All()
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
                return this.RedirectToAction("All");
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

            var publication = this.service.GetEditViewModel(id);
            if (publication == null)
            {
                return this.HttpNotFound();
            }

            return this.View(publication);
        }

        [HttpPost]
        [Route("AdminPosts/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPostBm post)
        {
            if (this.ModelState.IsValid)
            {
                this.service.Edit(post);
                return this.RedirectToAction("All");
            }

            var model = this.service.GetEditViewModel(post.Id);
            return this.View(model);
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
            return this.RedirectToAction("All");
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