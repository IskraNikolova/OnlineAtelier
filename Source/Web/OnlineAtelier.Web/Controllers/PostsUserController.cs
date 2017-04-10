﻿namespace OnlineAtelier.Web.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using Services.Contracts;

    [RoutePrefix("PostsUser")]
    public class PostsUserController : Controller
    {
        private readonly IPostService service;

        public PostsUserController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet, Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var publication = this.service.GetDetailsPostVModel((int)id);
            if (publication == null)
            {
                return this.HttpNotFound();
            }

            return this.View(publication);
        }

        [HttpGet, Route("PostGallery")]
        public ActionResult PostGallery()
        {
            var allByCategory = this.service.GroupByCategory();
            if (allByCategory == null)
            {
                return this.HttpNotFound();
            }

            return this.View(allByCategory);
        }

        public PartialViewResult Load(int id)
        {
            var model = this.service.GetPostsByCategory(id);
            return this.PartialView("_PostGalleryPartial", model);
        }
    }
}