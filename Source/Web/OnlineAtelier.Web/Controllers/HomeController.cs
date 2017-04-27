namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Models.ViewModels;
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
            var model = new ContactVm()
            {
                ApiKey = "AIzaSyBIRHww6KjTo7Z4a92cAsjEPHkxJpcAH2k"
            };
            return this.View(model);
        }
    }
}