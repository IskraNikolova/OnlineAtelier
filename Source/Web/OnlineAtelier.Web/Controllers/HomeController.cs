namespace OnlineAtelier.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data;
    using Data.Common.Repository;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using OnlineAtelier.Models.Models;

    public class HomeController : Controller
    {
        private IRepository<Category> categories;


        public HomeController(IRepository<Category> categories, IRepository<ApplicationUser> users)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {

            var category = this.categories.All();
            return this.View(category);
        }


        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}