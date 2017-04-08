namespace OnlineAtelier.Web.Models.ViewModels.UsersPicture
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class UserPictureViewModel : IMapFrom<PhotosOrder>
    {
        public int Id { get; set; }

        public byte[] UserPictures { get; set; }

        public int OrderId { get; set; }
    }
}