﻿using OnlineAtelier.Web.Models.BindingModels.Posts;

namespace OnlineAtelier.Web.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using Models.ViewModels.Posts;
    using Services.Contracts;

    [RoutePrefix("Posts")]
    public class PostsController : Controller
    {
        private readonly IPostService service;

        public PostsController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult All()
        {
            IEnumerable<IndexPostsVm> model = this.service.GetIndexPosts();
            return this.PartialView("_AllIndexPostsPartial", model);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.service.GetDetailsPostVModel((int)id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        [HttpGet]
        [Route("PostGallery")]
        public ActionResult PostGallery()
        {
            var allByCategory = this.service.GroupByCategory();
            if (allByCategory == null)
            {
                return this.HttpNotFound();
            }

            return this.View(allByCategory);
        }

        public PartialViewResult LoadPostByCategory(int? id)
        {
            var model = this.service.GetPostsByCategory((int)id);
            return this.PartialView("_PostGalleryPartial", model);
        }

        [HttpGet]
        [Route("Vote/{id}")]
        public ActionResult Vote(int? id)
        {
            return this.View();
        }

        [HttpPost]
        [Route("Vote/{id}")]
        public ActionResult Vote(VotePostBm postBm)
        {
            this.service.Vote(postBm);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ChildActionOnly]
        public PartialViewResult Rating()
        {
            var model = this.service.GetBestPosts();
            return this.PartialView("_RatingPostPartial", model);
        }
    }
}