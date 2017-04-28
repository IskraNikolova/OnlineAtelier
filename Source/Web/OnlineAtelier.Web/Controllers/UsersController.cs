namespace OnlineAtelier.Web.Controllers
{
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.Users;
    using Services.Contracts;

    [RoutePrefix("Users")]
    public class UsersController : ImageLoadController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("ProfilePage")]
        public ActionResult ProfilePage(string userId)
        {
            var userId1 = userId ?? this.User.Identity.GetUserId();
           
            var model = this.userService.GetProfileViewModel(userId1);
            return this.View(model);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editUserVm = this.userService.GetEditVm(id);
            if (editUserVm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(editUserVm);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "UserPhoto")]EditUserBm bind)
        {
            if (this.ModelState.IsValid)
            {
                byte[] imageData = null;
                if (this.Request.Files.Count > 0)
                {
                    HttpPostedFileBase httpPostedFileBase = this.Request.Files["UserPhoto"];

                    using (var binary = new BinaryReader(httpPostedFileBase.InputStream))
                    {
                        imageData = binary.ReadBytes(httpPostedFileBase.ContentLength);
                    }
                }

                this.userService.Edit(bind, imageData);
                return this.RedirectToAction("ProfilePage");
            }

            var editUserVm = this.userService.GetEditVm(bind.Id);
            return this.View(editUserVm);
        }

        [HttpGet]
        public FileContentResult UserPhotos(string id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string userId = id;
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