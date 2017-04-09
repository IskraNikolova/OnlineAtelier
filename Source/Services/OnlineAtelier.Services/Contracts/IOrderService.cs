namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    public interface IOrderService
    {
        void AddOrder(OrderBindingModel model, string authorId, Appearance appearance,
            Category category);

        AddOrderVm GetViewModel(OrderBindingModel model, IEnumerable<string> categories,
            IEnumerable<string> appearances);

        IEnumerable<DisplayOrderVm> GetOrders(string id);

        DetailsOrderVm GetDetails(int id);
    }
}