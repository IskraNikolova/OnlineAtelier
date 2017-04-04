namespace OnlineAtelier.Web.Models.ViewModels.UsersPicture
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AddPictureViewModel : IMapFrom<UserPicture>
    {
        public byte[] UserPictures { get; set; }
    }
}
