﻿namespace OnlineAtelier.Web.Models.ViewModels.Posts
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DetailsPostsVModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public Image Image { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
