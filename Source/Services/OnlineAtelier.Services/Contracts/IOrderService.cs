﻿namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;
    using Models.Models;
    using Web.Models.BindingModels;
    using Web.Models.BindingModels.Order;
    using Web.Models.ViewModels.Order;

    public interface IOrderService
    {
        void AddOrder(AddOrderVm model, string authorId, byte[] imageData);

        AddOrderVm GetViewModel(OrderBindingModel model);

        IEnumerable<string> GetAllCategories();

        IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements);

        IEnumerable<string> GetAllAppearances();

        IEnumerable<DisplayOrderVm> GetOrders(string id);

        DetailsOrderVm GetDetails(int id);
    }
}