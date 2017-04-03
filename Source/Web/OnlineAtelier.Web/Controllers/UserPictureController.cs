namespace OnlineAtelier.Web.Controllers
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using Logic;
    using Models.BindingModels;
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


        public FileContentResult TakePhotos(int id, int orderId)
        {
            var photo = this.service.TakePhoto(id, orderId);
            if (id == null || photo == null || photo.Length == 0)
            {
                return this.ImageLoad(@"~/Images/noImg.png");
            }

            return new FileContentResult(photo, "image/jpeg");
        }

        public FileContentResult ImageLoad(string path)
        {
            string fileName = this.HttpContext.Server.MapPath(path);

            byte[] imageData = GetImageData.GetIamge(fileName);

            return this.File(imageData, "image/png");
        }

        [HttpGet]
        public ActionResult All(int id)
        {
            var models = this.service.AllUserPicture(id);
            return this.PartialView("_ViewAllUserPicturePartial", models);
        }
    }
}