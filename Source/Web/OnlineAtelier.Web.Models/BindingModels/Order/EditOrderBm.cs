﻿namespace OnlineAtelier.Web.Models.BindingModels.Order
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class EditOrderBm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public decimal FinalPrice { get; set; }

        public string ShippingAddress { get; set; }

        public string ColorOfBox { get; set; }

        public string TextOfBox { get; set; }

        public string TextOfCookies { get; set; }

        public bool IsExecuted { get; set; }

        public bool IsАccepted { get; set; }
    }
}