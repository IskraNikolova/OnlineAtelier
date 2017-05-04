using OnlineAtelier.Models.Models;
using OnlineAtelier.Web.Infrastructure.Mapping;

namespace OnlineAtelier.Web.Models.BindingModels.Posts
{
    public class VotePostBm : IMapFrom<Post>
    {
        public int Id { get; set; }

        public int  Rate { get; set; }
    }
}