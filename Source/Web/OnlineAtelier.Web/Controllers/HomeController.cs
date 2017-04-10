namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IPostService service;

        public HomeController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = this.service.All();
            return this.View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return this.View();
        }
    }
}