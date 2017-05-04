namespace OnlineAtelier.Web.Models.ViewModels.Posts
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class GalleryPostVm : IMapFrom<Post>
    {
        public int Id { get; set; }

        public Image Image { get; set; }

        public int OrderId { get; set; }      
    }
}