namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
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
        public ActionResult AddComment(OrderCommentBm model, int id)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCommentToOrder(model, id);
                //if (this.User.IsInRole("Admin"))
                //{
                //    return this.RedirectToAction("Index", "AdminOrders", new {area="Admin"});
                //}//todo repeat this admin redirect after added comment

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


        [HttpGet]
        public ActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.Delete(id);
            return this.RedirectToAction("ProfilePage", "Users");
        }
    }
}