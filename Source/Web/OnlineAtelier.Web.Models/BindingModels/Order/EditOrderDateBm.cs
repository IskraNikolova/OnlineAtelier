namespace OnlineAtelier.Web.Models.BindingModels.Order
{
    using System;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class EditOrderDateBm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public DateTime DateOfDecision { get; set; }
    }
}
