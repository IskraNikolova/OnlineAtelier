namespace OnlineAtelier.Web.Controllers
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using Models.BindingModels.UserPicture;
    using Services.Contracts;

    [RoutePrefix("PhotosOrder")]
    public class PhotosOrderController : ImagesController
    {
        private readonly IUserPictureService service;

        public PhotosOrderController(IUserPictureService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AddPicture()
        {
            return this.PartialView("_AddPicturePartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            this.service.AddPictureToOrder(imageData, id);

            return this.RedirectToAction("Index", "ProfilePage");
        }

        [HttpGet]
        public FileContentResult TakePhoto(int id, int orderId)
        {
            var photo = this.service.TakePhotoFromOrder(id, orderId);
            if (id == null || photo == null || photo.Length == 0)
            {
                return null;
            }

            return new FileContentResult(photo, "image/jpeg");
        }



        [HttpGet, Route("TakePhoto/{id}")]
        public FileContentResult TakePhotoDetails(int id)
        {
            var photo = this.service.TakePhoto(id);

            return new FileContentResult(photo, "image/jpeg");
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult All(int id)
        {
            var models = this.service.AllUserPictures(id);
            return this.PartialView("_ViewAllUserPicturePartial", models);
        }
    }
}