namespace OnlineAtelier.Web.Models.BindingModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models.Comments;

    public class OrderCommentBindingModel : IMapFrom<OrderComment>
    {
        [Required]
        public string Text { get; set; }

        public int OrderId { get; set; }
    }
}