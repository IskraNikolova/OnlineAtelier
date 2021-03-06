﻿namespace OnlineAtelier.Web.Models.ViewModels.AdminArea.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class CreatePostsVm : IMapFrom<Post>
    {
        public int Id { get; set; }

        [DisplayName("Категория")]
        public string CategoryName { get; set; }

        [DisplayName("URL на изображение")]
        public string PhotoUrl { get; set; }

        [DisplayName("Заглавие")]
        public string Title { get; set; }

        [DisplayName("Съдържание")]
        public string Content { get; set; }

        // This property will hold all available categories for selection
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
