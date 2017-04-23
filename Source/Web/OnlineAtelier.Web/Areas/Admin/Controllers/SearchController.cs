namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Models.BindingModels.Users;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class SearchController : Controller
    {
        private readonly IUserService service;

        public SearchController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("Search/Search")]
        public ActionResult Search(SearchUserBm bm)
        {
            var userId = this.service.GetSearchUserId(bm);
            if (userId == null)
            {
                return this.RedirectToAction("Index", "AdminOrders");//todo change this
            }

            return this.RedirectToAction("ProfilePage","Users", new {area="", id = userId});
        }
    }
}