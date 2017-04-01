namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.OrderViewModels;
    using Services.Contracts;

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

            var model = new OrderViewModel
            {
                Categories = this.service.GetSelectListItems(categories),
                Appearances = this.service.GetSelectListItems(appearances)
            };

            // Create a list of SelectListItems so these can be rendered on the page
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(OrderBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var modelView = this.service.GetViewModel(model);
            if (this.ModelState.IsValid)
            {
                this.service.AddOrder(modelView, userId);
                return this.RedirectToAction("Index", "ProfilePage");
            }

            return this.View(this.service.GetViewModel(model));
        }
    }
}