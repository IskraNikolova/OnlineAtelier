namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Logic;
    using Models.BindingModels.Posts;
    using Models.ViewModels.AdminArea.Posts;
    using Models.ViewModels.Posts;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class PostsController : Controller
    {
        private readonly IPostService service;
        private readonly ICategoryService categoryService;

        public PostsController(IPostService service,
            ICategoryService categoryService)
        {
            this.service = service;
            this.categoryService = categoryService;
        }

        [HttpGet, Route("Posts/Index")]
        public ActionResult Index()
        {
            var posts = this.service.All();
            return this.View(posts);
        }

        [HttpGet, Route("Posts/Create")]
        public ActionResult Create()
        {
            var model = this.GetCreatePublicationVm();
            return this.View(model);
        }

        [HttpPost, Route("Posts/Create")]
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

        [HttpGet, Route("Posts/Edit")]
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

        [HttpPost, Route("Posts/Edit")]
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

        [HttpGet, Route("Posts/Delete")]
        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost, ActionName("Delete"), Route("Posts/Delete")]
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
