﻿namespace OnlineAtelier.Web.Models.ViewModels.Posts
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class PostVm : IMapFrom<Post>
    {
        public int Id { get; set; }

        public Image Image { get; set; }

        public Category Category { get; set; }
    }
}
