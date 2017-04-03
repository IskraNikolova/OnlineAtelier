namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models;
    using Web.Models.CommentsViewModels;

    public interface ICommentService : IService
    {
        void AddOrderComment(OrderCommentViewModel model, int? id, string userId);

        IEnumerable<OrderCommentViewModel> GetComments(int? id);
    }
}
