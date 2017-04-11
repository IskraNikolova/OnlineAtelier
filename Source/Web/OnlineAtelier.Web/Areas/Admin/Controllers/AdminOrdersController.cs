namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly IOrderService service;

        public AdminOrdersController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet, Route("AdminOrders/Index")]
        public ActionResult Index()
        {
            var models = this.service.GetAllNewOrders();
            return this.View(models);
        }
    }
}