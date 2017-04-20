namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;

    public class AppearanceController : Controller
    {
        private readonly IAppearanceService service;

        public AppearanceController(IAppearanceService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Appearance/PriceList")]
        public ActionResult PriceList()
        {
            var model = this.service.All();
            return this.View(model);
        }
    }
}