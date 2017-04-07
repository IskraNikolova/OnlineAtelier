namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using BindingModels.Order;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AddOrderVm : IMapFrom<OrderBindingModel>, IMapFrom<Order>
    {
        public int Id { get; set; }

        [DisplayName("Вид на поръчката/Количество")]
        public string AppearanceName { get; set; }
      
        [DisplayName("Детайли")]
        public string Details { get; set; }

        [DisplayName("Категория")]
        public string Category { get; set; }

        [DisplayName("Цветова гама")]
        public string ColorOfBox { get; set; }

        [DisplayName("Надпис/послание на кутията отгоре")]
        public string TextOfBox { get; set; }

        [DisplayName("Надпис/и върху сладка/и")]
        public string TextOfCookies { get; set; }

        [DisplayName("Дата за получаване")]
        public DateTime DateOfDecision { get; set; }

        [DisplayName("Адрес за получаване")]
        public string ShippingAddress { get; set; }

        // This property will hold all available categories for selection
        public IEnumerable<SelectListItem> Categories { get; set; }

        // This property will hold all available appearances of orders for selection
        public IEnumerable<SelectListItem> Appearances { get; set; }
    }
}