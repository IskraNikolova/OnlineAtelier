namespace OnlineAtelier.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Models.BindingModels.Publications;
    using Services.Contracts;

    [RoutePrefix("Publications")]
    public class PublicationsController : Controller
    {
        private readonly IPublicationsService service;

        public PublicationsController(IPublicationsService service)
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

            var publication = this.service.GetDetailsPublicationVModel((int)id);
            if (publication == null)
            {
                return this.HttpNotFound();
            }

            return this.View(publication);
        }

        [HttpGet, Route("Create")]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublicationBm publication)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddPublication(publication);
                return this.RedirectToAction("Index","Home");
            }

            return this.View(publication);
        }

        [HttpGet, Route("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var publication = this.service.GetViewModel(id);
            if (publication == null)
            {
                return this.HttpNotFound();
            }

            return this.View(publication);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublicationBm publication)
        {
            if (this.ModelState.IsValid)
            {
                this.service.Edit(publication);
                return this.RedirectToAction("Index","Home");
            }

            return this.View(publication);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.Delete(id);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
