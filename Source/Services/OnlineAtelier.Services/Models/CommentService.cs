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

        public void AddCommentToOrder(OrderCommentBm model, int orderId)
        {
            var orderCommentVm = Mapper.Map<OrderCommentBm, OrderComment>(model);
            orderCommentVm.ApplicationUserId = model.UserId;
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

        public void Delete(int id)
        {
            var entity = this.comments.GetById(id);
            this.comments.Delete(entity);
            this.comments.SaveChanges();
        }
    }
}