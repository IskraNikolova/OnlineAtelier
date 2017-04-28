namespace OnlineAtelier.Web.Models.BindingModels.Posts
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class PostBm : IMapFrom<Post>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Избери снимка.")]
        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Required(ErrorMessage = "Избери категория.")]
        public string CategoryName { get; set; }
    }
}
