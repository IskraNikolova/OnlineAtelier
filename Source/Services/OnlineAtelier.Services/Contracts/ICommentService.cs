﻿namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.BindingModels.Comments;
    using Web.Models.ViewModels.Comments;

    public interface ICommentService : IDeletable
    {
        void AddCommentToOrder(OrderCommentBindingModel model, int orderId, string userId);

        IEnumerable<OrderCommentViewModel> GetComments(int id);
    }
}