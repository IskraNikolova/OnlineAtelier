using OnlineAtelier.Models.Models;
using OnlineAtelier.Web.Infrastructure.Mapping;

namespace OnlineAtelier.Web.Models.ViewModels.Posts
{
    public class VotePostVm : IMapFrom<Post>
    {
        public int Id { get; set; }

        public int Rate { get; set; }
    }
}