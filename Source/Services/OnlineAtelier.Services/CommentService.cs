namespace OnlineAtelier.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models.Comments;
    using Web.Models.CommentsViewModels;


    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment>  comments)
        {
            this.comments = comments;
        }

        public void AddOrderComment(OrderCommentViewModel model, int? id, string userId)
        {
            var comment = new OrderComment()
            {
                Text = model.Text,
                OrderId = (int)id,
                ApplicationUserId = userId
            };

            this.comments.Add(comment);
            this.comments.SaveChanges();
        }

        public IEnumerable<OrderCommentViewModel> GetComments(int? id)
        {
            var commentsModels = this.comments.All().ToList();
            var result = new List<OrderCommentViewModel>();
            foreach (var orderComment in commentsModels)
            {
                var oc = orderComment as OrderComment;
                if (oc.OrderId == id)
                {
                    var model = new OrderCommentViewModel()
                    {
                        ApplicationUserId = oc.ApplicationUserId,
                        Text = oc.Text,
                    };

                    result.Add(model);
                }
            }

            return result;
        }
    }
}
