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
    using OnlineAtelier.Models.Enums;
    using OnlineAtelier.Models.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }


        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }
    }
}