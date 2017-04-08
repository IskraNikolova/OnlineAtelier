namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;


    public class HomeController : Controller
    {
        private IPublicationsService service;

        public HomeController(IPublicationsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.All();
            return this.View(model);
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