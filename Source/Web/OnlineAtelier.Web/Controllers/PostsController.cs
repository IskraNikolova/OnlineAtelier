namespace OnlineAtelier.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Services.Contracts;

    [RoutePrefix("Posts")]
    public class PostsController : Controller
    {
        private readonly IPostService service;

        public PostsController(IPostService service)
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
    }
}