namespace OnlineAtelier.Web.Models.ViewModels.Comments
{
    using System;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models.Comments;

    public class OrderCommentViewModel : IMapFrom<Comment>
    {
        public string Text { get; set; }

        public int OrderId { get; set; }

        public  string ApplicationUserId  { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}