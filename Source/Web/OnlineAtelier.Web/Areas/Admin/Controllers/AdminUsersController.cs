namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts;

    public class AdminUsersController : BaseAdminController
    {
        private readonly IUserService service;

        public AdminUsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("AdminUsers/Phonebook")]
        public ActionResult Phonebook()
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