namespace OnlineAtelier.Web.Models.ViewModels.Posts
{
    using System;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class IndexPostsVm : IMapFrom<Post>
    {
        public int Id { get; set; }

        public Image Image { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
