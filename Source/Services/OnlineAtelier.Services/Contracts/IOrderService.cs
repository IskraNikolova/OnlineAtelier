namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Web.Models.BindingModels;
    using Web.Models.OrderViewModels;

    public interface IOrderService
    {
        void AddOrder(OrderViewModel model, string authorId);

        OrderViewModel GetViewModel(OrderBindingModel model);

        IEnumerable<string> GetAllCategories();

        IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements);

        IEnumerable<string> GetAllAppearances();
    }
}