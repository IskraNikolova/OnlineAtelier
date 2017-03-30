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
        private IRepository<Order> orders;


        public HomeController(IRepository<Order> orders)
        {
            this.orders = orders;
        }

        public ActionResult Index()
        {

            var order = new Order()
            {
                SizeOfTheBox = SizeOfTheBox.StandardFour,
                ApplicationUserId = this.User.Identity.GetUserId(),
                Category = "new",

            };

            this.orders.Add(order);
            this.orders.SaveChanges();

            return this.View(order);
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