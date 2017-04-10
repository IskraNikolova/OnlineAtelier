namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;

    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private readonly IPostService service;

        public HomeController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet, Route("Index")]
        public ActionResult Index()
        {
            var model = this.service.All();
            return this.View(model);
        }

        [HttpGet, Route("About")]
        public ActionResult About()
        {
            return this.View();
        }

        [HttpGet, Route("Contact")]
        public ActionResult Contact()
        {
            return this.View();
        }
    }
}