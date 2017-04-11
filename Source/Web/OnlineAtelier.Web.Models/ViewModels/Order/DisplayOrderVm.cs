namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DisplayOrderVm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AppearanceName { get; set; }

        public decimal AppearancePrice { get; set; }

        public ICollection<Order> ProfileOrders { get; set; }
    }
}