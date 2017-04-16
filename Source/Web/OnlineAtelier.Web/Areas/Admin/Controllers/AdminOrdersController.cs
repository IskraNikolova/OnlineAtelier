namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Logic;
    using Models.BindingModels.Order;
    using Models.ViewModels.Order;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly IOrderService service;
        private readonly IFigureService figureService;

        public AdminOrdersController(IOrderService service, IFigureService figureService)
        {
            this.service = service;
            this.figureService = figureService;
        }

        [HttpGet, Route("AdminOrders/Index")]
        public ActionResult Index()
        {
            var models = this.service.GetAllNewOrders();
            return this.View(models);
        }


        [HttpGet, Route("AdminOrders/Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = this.service.GetEditViewModel(id);
            if (order == null)
            {
                return this.HttpNotFound();
            }

            return this.View(order);
        }

        [HttpGet, Route("AdminOrders/DesignIt/{id}")]
        public ActionResult DesignIt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = this.GetDesignOrderVm(id);

            return this.View(model);
        }

        private DesignOrderVm GetDesignOrderVm(int? id)
        {
            var model = this.service.GetDesignOrderVm((int) id);

            model.FiguresSelectList = GetListItem.GetSelectListItems(this.figureService.GetAllFigures());
            return model;
        }

        [HttpPost, Route("AdminOrders/DesignIt/{id}")]
        public ActionResult DesignIt(DesignOrderBm bm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddFigures(bm);
                return this.View(this.GetDesignOrderVm(bm.Id));
            }

            return this.View(this.GetDesignOrderVm(bm.Id));
        }

        [HttpPost, Route("AdminOrders/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditOrderBm orderBm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.Edit(orderBm);
                return this.RedirectToAction("Index");
            }

            return this.View(orderBm);
        }


        [HttpGet, Route("AdminOrders/Delete")]
        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost, ActionName("Delete"), Route("AdminOrders/Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.Delete(id);
            return this.RedirectToAction("Index");
        }
    }
}