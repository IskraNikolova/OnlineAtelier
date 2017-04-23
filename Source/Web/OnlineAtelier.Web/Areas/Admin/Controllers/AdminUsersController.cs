namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.ViewModels.Users;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IUserService service;

        public AdminUsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("AdminUsers/Index")]
        public ActionResult Index()
        {
            var model = this.service.GetAllUsers();
            return this.View(model);
        }

        [Route("AdminUsers/AdminSearch")]
        public ActionResult AdminSearch(string query)
        {
            var models = this.service.GetSearchUsers(query);
            return this.PartialView("_UsersPartial", models);
        }
    }
}