namespace OnlineAtelier.Web.Controllers
{
    using System.Web.Mvc;
    using Logic;

    public abstract class ImagesController : Controller
    {

        public FileContentResult ImageLoad(string path)
        {
            string fileName = this.HttpContext.Server.MapPath(path);

            byte[] imageData = GetImageData.GetIamge(fileName);

            return this.File(imageData, "image/png");
        }
    }
}