namespace OnlineAtelier.Web.Controllers
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using Models.BindingModels;
    using Services;
    using Services.Contracts;

    public class UserPictureController : Controller
    {
        private readonly IUserPictureService service;

        public UserPictureController(IUserPictureService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult AddPicture()
        {
            return this.PartialView("_AddPicturePartial");
        }

        [HttpPost]
        public ActionResult AddPicture([Bind(Exclude = "UserPictures")]AddPictureBindingModel model, int id)
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

            this.service.AddPicture(imageData, id);
            return this.RedirectToAction("Index", "ProfilePage");
        }
    }
}