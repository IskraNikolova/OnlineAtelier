namespace OnlineAtelier.Web.Areas.Admin.Controllers
{

    using System.Web.Mvc;
    using Microsoft.AspNet.SignalR;
    using Hubs;

    public class NotificationsController : BaseAdminController
    {
        [HttpGet]
        [Route("Notifications")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        [Route("Notifications")]
        public ActionResult SendNotification(string type, string notification)
        {
            var hubContext = GlobalHost
                .ConnectionManager
                .GetHubContext<NotificationsHub>();

            hubContext
                .Clients
                .All
                .receiveNotification(type, notification);

            return this.Content("Notification sent.<br />");
        }
    }
}