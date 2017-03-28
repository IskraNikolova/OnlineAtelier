namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;

    public class HomeController : Controller
    {
        private IRepository<Category> categories;

        public HomeController(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var category = this.categories.All();
            return View(category);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}