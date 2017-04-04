namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.ViewModels.Comments;

    public interface ICommentService : IService
    {
        void AddOrderComment(OrderCommentViewModel model, int? id, string userId);

        IEnumerable<OrderCommentViewModel> GetComments(int? id);
    }
}
