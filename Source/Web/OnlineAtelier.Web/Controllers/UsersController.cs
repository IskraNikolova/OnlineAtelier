namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;

    public class UsersController : ImagesController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult ProfilePage()
        {
            var userId = this.User.Identity.GetUserId();
            var model = this.userService.GetProfileViewModel(userId);
            return this.View(model);
        }

        [HttpGet]
        public FileContentResult UserPhotos()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string userId = this.User.Identity.GetUserId();
                var user = this.userService.GetUser(userId);

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
            var user = this.userService.GetUser(id);

            if (id == null || user.UserPhoto == null || user.UserPhoto.Length == 0)
            {
                return this.ImageLoad(@"~/Images/noImg.png");
            }

            return new FileContentResult(user.UserPhoto, "image/jpeg");
        }
    }
}