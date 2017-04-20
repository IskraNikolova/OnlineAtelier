namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    public interface IOrderService : IDeletable
    {
        void AddOrder(OrderBindingModel model, string authorId, Appearance appearance,
            Category category);

        AddOrderVm GetAddOrderVm(OrderBindingModel model, IEnumerable<string> categories,
            IEnumerable<string> appearances);

        IEnumerable<DisplayOrderVm> GetOrders(string id);

        DetailsOrderVm GetDetails(int id);

        IEnumerable<DisplayOrderVm> GetAllNewOrders();

        EditOrderVm GetEditViewModel(int? id);

        EditOrderDateVm GetEditDateViewModel(int? id);

        void Edit(EditOrderBm model);

        void EditDate(EditOrderDateBm model);

        void AddFigures(DesignOrderBm bm);

        DesignOrderVm GetDesignOrderVm(int? id);
    }
}