namespace OnlineAtelier.Web.Areas.Admin.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Models.BindingModels.Order;
    using Services.Contracts;

    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly IOrderService service;

        public AdminOrdersController(IOrderService service)
        {
            this.service = service;
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

            var order = this.service.GetViewModel(id);
            if (order == null)
            {
                return this.HttpNotFound();
            }

            return this.View(order);
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