namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Logic;
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

        public FileContentResult ImageLoad(string path)
        {
            string fileName = this.HttpContext.Server.MapPath(path);

            byte[] imageData = GetImageData.GetIamge(fileName);

            return this.File(imageData, "image/png");
        }

        public FileContentResult UserPhotos()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string userId = this.User.Identity.GetUserId();
                var user = this.profileService.GetUser(userId);

                if (userId == null || user.UserPhoto == null || user.UserPhoto.Length == 0)
                {
                    return this.ImageLoad(@"~/Images/noImg.png");
                }

                return new FileContentResult(user.UserPhoto, "image/jpeg");
            }
            else
            {
                return this.ImageLoad(@"~/Images/noImg.png");
            }
        }

        public FileContentResult TakeUserPhotos(string id)
        {
            var user = this.profileService.GetUser(id);

            if (id == null || user.UserPhoto == null || user.UserPhoto.Length == 0)
            {
                return this.ImageLoad(@"~/Images/noImg.png");
            }

            return new FileContentResult(user.UserPhoto, "image/jpeg");
        }
    }
}