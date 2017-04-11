namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdministrationsController : Controller
    {
        [HttpGet, Route("Administrations/Index")]
        public ActionResult Index()
        {
           
            return this.View();
        }
    }
}