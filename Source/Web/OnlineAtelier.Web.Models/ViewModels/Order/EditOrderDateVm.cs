namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class EditOrderDateVm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public DateTime DateOfDecision { get; set; }
    }
}