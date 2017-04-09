namespace OnlineAtelier.Web.Models.BindingModels.Order
{
    using System;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class OrderBindingModel : IMapFrom<Order>
    {
        public string Details { get; set; }

        public string CategoryName { get; set; }

        public string AppearanceName { get; set; }

        public DateTime DateOfDecision { get; set; }

        public string ShippingAddress { get; set; }

        public string ColorOfBox { get; set; }

        public string TextOfBox { get; set; }

        public string TextOfCookies { get; set; }
    }
}