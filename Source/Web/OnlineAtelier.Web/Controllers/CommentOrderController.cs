namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.Comments;
    using Services.Contracts;

    public class CommentOrderController : Controller
    {
        private readonly ICommentService service;

        public CommentOrderController(ICommentService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AddComment(int id)
        {
            return this.PartialView("_AddCommentPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(OrderCommentBindingModel model, int id)
        {
            string userId = this.User.Identity.GetUserId();

            if (this.ModelState.IsValid)
            {
                this.service.AddCommentToOrder(model, id, userId);
                return this.RedirectToAction("ProfilePage", "Users");
            }

            return this.RedirectToAction("ProfilePage", "Users");
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetComments(int id)
        {
            var model = this.service.GetComments(id);
            return this.PartialView("_ViewCommentsPartial", model);
        }
    }
}