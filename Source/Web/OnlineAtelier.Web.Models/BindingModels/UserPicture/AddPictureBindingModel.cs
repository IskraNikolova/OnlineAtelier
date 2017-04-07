namespace OnlineAtelier.Web.Models.BindingModels.UserPicture
{
    using System.ComponentModel.DataAnnotations;

    public class AddPictureBindingModel
    {
        public int Id { get; set; }

        [Display(Name = "UserPictures")]
        [Required]
        public byte[] UserPictures { get; set; }
    }
}
