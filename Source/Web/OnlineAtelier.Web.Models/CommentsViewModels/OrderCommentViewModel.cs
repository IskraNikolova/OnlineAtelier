namespace OnlineAtelier.Web.Models.CommentsViewModels
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models.Comments;

    public class OrderCommentViewModel : IMapFrom<Comment>
    {
        public string Text { get; set; }

        public  string ApplicationUserId  { get; set; }
    }
}