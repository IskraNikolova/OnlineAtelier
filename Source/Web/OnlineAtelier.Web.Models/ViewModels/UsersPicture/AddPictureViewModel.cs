namespace OnlineAtelier.Web.Models.ViewModels.UsersPicture
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AddPictureViewModel : IMapFrom<UserPicture>
    {
        [Required]
        public byte[] UserPictures { get; set; }
    }
}
