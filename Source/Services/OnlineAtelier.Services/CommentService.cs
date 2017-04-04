namespace OnlineAtelier.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models.Comments;
    using Web.Models.BindingModels;
    using Web.Models.ViewModels.Comments;


    public class CommentService : ICommentService
    {
        private readonly IRepository<OrderComment> comments;

        public CommentService(IRepository<OrderComment>  comments)
        {
            this.comments = comments;
        }

        public void AddOrderComment(OrderCommentBindingModel model, int? id, string userId)
        {
            if (id == null) return;
            var orderComment = new OrderComment()
            {
                Text = model.Text,               
                OrderId = (int)id,
                ApplicationUserId = userId
            };

            this.comments.Add(orderComment);
            this.comments.SaveChanges();
        }

        public IEnumerable<OrderCommentViewModel> GetComments(int? id)
        {
            var commentsModels = this.comments.All()
                .Where(c => c.OrderId == id)
                .ToList();

            var result = new List<OrderCommentViewModel>();

            foreach (var orderComment in commentsModels)
            {
                var model = new OrderCommentViewModel()
                {
                    ApplicationUserId = orderComment.ApplicationUserId,
                    Text = orderComment.Text,
                    
                };

               result.Add(model);
            }

            return result;
        }
    }
}
