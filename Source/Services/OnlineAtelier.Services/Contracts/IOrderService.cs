namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;
    using Models.Models;
    using Web.Models.BindingModels;
    using Web.Models.ViewModels.Order;
    using Web.Models.ViewModels.ProfilePage;

    public interface IOrderService
    {
        void AddOrder(OrderViewModel model, string authorId, byte[] imageData);

        OrderViewModel GetViewModel(OrderBindingModel model);

        IEnumerable<string> GetAllCategories();

        IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements);

        IEnumerable<string> GetAllAppearances();

        IEnumerable<ProfileOrdersViewModel> GetOrders(string id);
    }
}