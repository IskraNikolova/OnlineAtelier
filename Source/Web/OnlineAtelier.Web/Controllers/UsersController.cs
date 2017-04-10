﻿namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.Users;
    using Models.ViewModels.Users;
    using Services.Contracts;

    [RoutePrefix("Users")]
    public class UsersController : ImagesController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet, Route("ProfilePage")]
        public ActionResult ProfilePage()
        {
            var userId = this.User.Identity.GetUserId();
            var model = this.userService.GetProfileViewModel(userId);
            return this.View(model);
        }

        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit()
        {
            var editUserVm = this.GetEditUserVm();
            return this.View(editUserVm);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserBm bind)
        {

            if (this.ModelState.IsValid)//todo check is email is uniq
            {
                this.userService.Edit(bind);
                return this.RedirectToAction("ProfilePage");
            }

            var editUserVm = this.GetEditUserVm();
            return this.View(editUserVm);
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


        private EditUserVm GetEditUserVm()
        {
            var userId = this.User.Identity.GetUserId();
            EditUserVm editUserVm = this.userService.GetEditVm(userId);
            return editUserVm;
        }
    }
}