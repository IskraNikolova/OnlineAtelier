namespace OnlineAtelier.Web.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    using Logic;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.Order;
    using Models.ViewModels.Order;
    using Services.Contracts;

    [RoutePrefix("Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICategoryService categoryService;
        private readonly IAppearanceService appearanceService;

        public OrderController(IOrderService orderService, 
            ICategoryService categoryService, 
            IAppearanceService appearanceService)
        {
            this.orderService = orderService;
            this.categoryService = categoryService;
            this.appearanceService = appearanceService;
        }

        [HttpGet]
        [Route("Add")]
        [Authorize]
        public ActionResult Add()
        {
            var model = this.GetAddOrderVm();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OrderBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.orderService.AddOrder(model);
                return this.RedirectToAction("ProfilePage", "Users");
            }

            return this.View(this.GetAddOrderVm());
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOrders(string id)
        {
            IEnumerable<DisplayOrderVm> model = this.orderService.GetOrders(id);
            return this.PartialView("_GetOrdersPartial", model);
        }

        [HttpGet]
        [Authorize]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            DetailsOrderVm detailsOrderVm = this.orderService.GetDetails(id);
            if (detailsOrderVm == null)
            {
                return this.HttpNotFound();
            }  
             
            return this.View(detailsOrderVm);
        }

        private AddOrderVm GetAddOrderVm()
        {
            var model = new AddOrderVm
            {
                Categories = GetListItem.GetSelectListItems(this.categoryService.GetAllCategories()),
                Appearances = GetListItem.GetSelectListItems(this.appearanceService.GetAllNameOfAppearances())
            };

            return model;
        }
    }
}