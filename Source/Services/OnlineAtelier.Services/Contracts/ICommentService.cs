namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.BindingModels;
    using Web.Models.BindingModels.Comments;
    using Web.Models.ViewModels.Comments;

    public interface ICommentService : IService
    {
        void AddOrderComment(OrderCommentBindingModel model, int id, string userId);

        IEnumerable<OrderCommentViewModel> GetComments(int id);
    }
}
