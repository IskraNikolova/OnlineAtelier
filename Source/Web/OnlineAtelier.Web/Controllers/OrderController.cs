namespace OnlineAtelier.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.Order;
    using Models.ViewModels.Order;
    using Services.Contracts;

    [RoutePrefix("Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var categories = this.service.GetAllCategories();
            var appearances = this.service.GetAllAppearances();

            var model = new AddOrderVm
            {
                Categories = this.service.GetSelectListItems(categories),
                Appearances = this.service.GetSelectListItems(appearances)
            };

            // Create a list of SelectListItems so these can be rendered on the page
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OrderBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var modelView = this.service.GetViewModel(model);

            if (this.ModelState.IsValid)
            {
                this.service.AddOrder(modelView, userId);
                return this.RedirectToAction("ProfilePage", "Users");
            }

            return this.View(this.service.GetViewModel(model));
        }


        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOrders(string id)
        {
            IEnumerable<DisplayOrderVm> model = this.service.GetOrders(id);
            return this.PartialView("_GetOrdersPartial", model);
        }

        [Authorize]
        [HttpGet, Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            DetailsOrderVm detailsOrderVm = this.service.GetDetails(id);
            if (detailsOrderVm == null)
            {
                return this.HttpNotFound();
            }  
             
            return this.View(detailsOrderVm);
        }
    }
}