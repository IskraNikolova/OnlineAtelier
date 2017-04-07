namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models.Comments;
    using Web.Models.BindingModels.Comments;
    using Web.Models.ViewModels.Comments;

    public class CommentService : ICommentService
    {
        private readonly IRepository<OrderComment> comments;

        public CommentService(IRepository<OrderComment>  comments)
        {
            this.comments = comments;
        }

        public void AddCommentToOrder(OrderCommentBindingModel model, int orderId, string userId)
        {
            var orderCommentVm = Mapper.Map<OrderCommentBindingModel, OrderComment>(model);
            orderCommentVm.ApplicationUserId = userId;
            orderCommentVm.OrderId = orderId;

            this.comments.Add(orderCommentVm);
            this.comments.SaveChanges();
        }

        public IEnumerable<OrderCommentViewModel> GetComments(int id)
        {
            var orderCommentsVm = this.comments
                .All()
                .Where(c => c.OrderId == id)
                .Project()
                .To<OrderCommentViewModel>()
                .ToList();

            return orderCommentsVm;
        }
    }
}