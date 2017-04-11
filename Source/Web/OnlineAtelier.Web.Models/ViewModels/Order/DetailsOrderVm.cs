namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DetailsOrderVm : IMapFrom<Order>
    {
        [DisplayName("Детайли")]
        public string Details { get; set; }

        [DisplayName("Категория")]
        public string CategoryName { get; set; }

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
    }
}