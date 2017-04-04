namespace OnlineAtelier.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using Models.Models.Comments;
    using Web.Models.BindingModels;
    using Web.Models.ViewModels.Comments;


    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment>  comments)
        {
            this.comments = comments;
        }

        public void AddOrderComment(OrderCommentBindingModel model, int? id, string userId)
        {
            if (id == null) return;
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
            var commentsModels = this.comments.All().Where(c => c is OrderComment).Project().To<OrderCommentViewModel>().ToList();
            var result1 = commentsModels.Where(c => c.OrderId == id);

            //var commentsModels1 = this.comments.All().ToList();
            //var result = new List<OrderCommentViewModel>();

            //foreach (var orderComment in commentsModels)
            //{
            //    var oc = orderComment as OrderComment;
            //    if (oc != null && oc.OrderId == id)
            //    {
            //        var model = new OrderCommentViewModel()
            //        {
            //            ApplicationUserId = oc.ApplicationUserId,
            //            Text = oc.Text,
            //            CreatedOn = oc.CreatedOn
            //        };

            //        result.Add(model);
            //    }
            //}

            return result1;
        }
    }
}
