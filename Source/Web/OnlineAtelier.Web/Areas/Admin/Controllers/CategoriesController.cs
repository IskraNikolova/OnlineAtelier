namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using Models.BindingModels.Categories;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class CategoriesController : Controller
    {
        private ICategoryService service;

        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Categories/Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Categories/Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddCategoryBm bm)
        {
            if(ModelState.IsValid)
            {
                this.service.AddNewCategory(bm);
                return this.RedirectToAction("All", "AdminPosts");
            }

            return this.View();
        }
    }
}