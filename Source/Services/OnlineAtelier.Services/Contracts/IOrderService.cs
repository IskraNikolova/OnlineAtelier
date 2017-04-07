namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    public interface IOrderService
    {
        void AddOrder(AddOrderVm model, string authorId);

        AddOrderVm GetViewModel(OrderBindingModel model);

        IEnumerable<string> GetAllCategories();

        IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements);

        IEnumerable<string> GetAllAppearances();

        IEnumerable<DisplayOrderVm> GetOrders(string id);

        DetailsOrderVm GetDetails(int id);
    }
}