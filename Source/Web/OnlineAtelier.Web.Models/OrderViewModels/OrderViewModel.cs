namespace OnlineAtelier.Web.Models.OrderViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class OrderViewModel 
    {
        public int Id { get; set; }

        public string Appearance { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

        public string ColorOfBox { get; set; }

        public string TextOfBox { get; set; }

        public string TextOfCookies { get; set; }

        public DateTime DateOfDecision { get; set; }

        public string ShippingAddress { get; set; }

        // This property will hold all available categories for selection
        public IEnumerable<SelectListItem> Categories { get; set; }

        // This property will hold all available appearances of orders for selection
        public IEnumerable<SelectListItem> Appearances { get; set; }
    }
}