namespace OnlineAtelier.Web.Models.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models.Comments;

    public class OrderCommentViewModel : IMapFrom<OrderComment>
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int OrderId { get; set; }

        public  string ApplicationUserId  { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}