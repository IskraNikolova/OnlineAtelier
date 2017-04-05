namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DisplayOrderVm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AppearanceName { get; set; }

        public decimal AppearancePrice { get; set; }
    }
}