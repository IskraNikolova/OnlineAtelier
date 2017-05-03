using OnlineAtelier.Models.Models;
using OnlineAtelier.Web.Infrastructure.Mapping;

namespace OnlineAtelier.Web.Models.ViewModels.AdminArea.Posts
{
    public class EditPostVm : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}