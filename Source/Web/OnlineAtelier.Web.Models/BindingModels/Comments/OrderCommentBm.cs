namespace OnlineAtelier.Web.Models.BindingModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models.Comments;

    public class OrderCommentBm : IMapFrom<OrderComment>
    {
        public string UserId { get; set; }

        [Required]
        public string Text { get; set; }

        public int OrderId { get; set; }
    }
}