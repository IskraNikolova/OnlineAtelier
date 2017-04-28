namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Services.Contracts;
    using Models.BindingModels.Appearance;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminAppearanceController : Controller
    {
        private readonly IAppearanceService service;

        public AdminAppearanceController(IAppearanceService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("AdminAppearance/Create")]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Route("AdminAppearance/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppearanceCreateBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddAppearance(bind);
                return this.RedirectToAction("PriceList", "Appearance", new { area = "" });
            }

            var model = this.service.GetAppearanceCreateVm(bind);
            return this.View(model);
        }

        [HttpGet]
        [Route("AdminAppearance/Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appearance = this.service.GetAppearanceEditVm(id);
            if (appearance == null)
            {
                return this.HttpNotFound();
            }

            return this.View(appearance);
        }

        [HttpPost]
        [Route("AdminAppearance/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppearanceEditBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.Edit(bind);
                return this.RedirectToAction("PriceList", "Appearance", new {area=""});
            }

            var appearanceEditVm = this.service.GetAppearanceEditVm(bind.Id);
            return this.View(appearanceEditVm);
        }

        [HttpGet]
        [Route("AdminAppearance/Delete")]
        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost, ActionName("Delete")]
        [Route("AdminAppearance/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.Delete(id);
            return this.RedirectToAction("PriceList", "Appearance", new { area = "" });
        }
    }
}