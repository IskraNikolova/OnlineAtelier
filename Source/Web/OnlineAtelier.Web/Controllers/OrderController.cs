namespace OnlineAtelier.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
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
        [ValidateAntiForgeryToken]
        public ActionResult Add(OrderBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var modelView = this.service.GetViewModel(model);

            if (this.ModelState.IsValid)
            {
                byte[] imageData = null;
                if (this.Request.Files.Count > 0)
                {
                    HttpPostedFileBase httpPostedFileBase = this.Request.Files["UserPictures"];

                    using (var binary = new BinaryReader(httpPostedFileBase.InputStream))
                    {
                        imageData = binary.ReadBytes(httpPostedFileBase.ContentLength);
                    }
                }
          
                this.service.AddOrder(modelView, userId, imageData);
                return this.RedirectToAction("Index", "ProfilePage");
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