using System.ComponentModel.DataAnnotations;
using OnlineAtelier.Models.Models;
using OnlineAtelier.Web.Infrastructure.Mapping;

namespace OnlineAtelier.Web.Models.BindingModels.Posts
{
    public class EditPostBm : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}