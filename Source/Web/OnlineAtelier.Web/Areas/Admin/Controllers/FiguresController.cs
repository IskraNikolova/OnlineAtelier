namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Models.BindingModels.Figures;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class FiguresController : Controller
    {
        private readonly IFigureService service;

        public FiguresController(IFigureService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Figures/Add")]
        [Authorize]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Figures/Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FigureBm model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddFigure(model);
                return this.RedirectToAction("All", "AdminPosts");
            }

            return this.View();
        }

        [HttpGet, Route("Figures/Delete")]
        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost, ActionName("Delete"), Route("Figures/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.Delete(id);
            return this.RedirectToAction("All", "AdminPosts");
        }
    }
}