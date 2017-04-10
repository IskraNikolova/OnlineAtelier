namespace OnlineAtelier.Web.Models.ViewModels.Posts
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class GalleryPostVm : IMapFrom<Post>
    {
        public string PhotoUrl { get; set; }
    }
}
