namespace OnlineAtelier.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPictureBindingModel
    {
        public int Id { get; set; }

        [Display(Name = "UserPictures")]
        public byte[] UserPictures { get; set; }
    }
}
