namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;

    public class UserProfilePictureController : ImagesController
    {
        private readonly IProfileService profileService;

        public UserProfilePictureController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
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

        [HttpGet]
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