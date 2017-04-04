namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;

    public class ProfilePageController : Controller
    {
        private readonly IProfileService profileService;

        public ProfilePageController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        // GET: ProfilePage
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var model = this.profileService.GetProfilePageViewModel(userId);
            return this.View(model);
        }
    }
}