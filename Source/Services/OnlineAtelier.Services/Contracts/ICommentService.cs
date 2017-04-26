namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.BindingModels.Comments;
    using Web.Models.ViewModels.Comments;

    public interface ICommentService : IDeletable
    {
        void AddCommentToOrder(OrderCommentBm model, int orderId);

        IEnumerable<OrderCommentViewModel> GetComments(int id);
    }
}