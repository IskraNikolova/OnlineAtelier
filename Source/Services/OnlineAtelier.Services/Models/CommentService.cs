namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
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
            var oC = Mapper.Map<OrderCommentBindingModel, OrderComment>(model);
            oC.ApplicationUserId = userId;
            oC.OrderId = orderId;

            this.comments.Add(oC);
            this.comments.SaveChanges();
        }

        public IEnumerable<OrderCommentViewModel> GetComments(int id)
        {
            var orderComments = this.comments.All()
                .Where(c => c.OrderId == id)
                .ToList();

            var result = new List<OrderCommentViewModel>();

            foreach (var entity in orderComments)
            {
               var orderCommentVm = Mapper.Map<OrderComment, OrderCommentViewModel>(entity);
               result.Add(orderCommentVm);
            }

            return result;
        }
    }
}