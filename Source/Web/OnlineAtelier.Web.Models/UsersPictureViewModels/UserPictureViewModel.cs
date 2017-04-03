namespace OnlineAtelier.Web.Models.UsersPictureViewModels
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class UserPictureViewModel : IMapFrom<UserPicture>
    {
        public int Id { get; set; }

        public byte[] UserPictures { get; set; }

        public int OrderId { get; set; }
    }
}