namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using BindingModels.Order;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class AddOrderVm : IMapFrom<OrderBindingModel>, IMapFrom<Order>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Избери {0}")]
        [DisplayName("Вид на поръчката/Количество")]
        public string AppearanceName { get; set; }

        [DisplayName("Детайли")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Избери {0}")]
        [DisplayName("Категория")]
        public string CategoryName { get; set; }

        [DisplayName("Цветова гама")]
        [DataType(DataType.Text)]
        public string ColorOfBox { get; set; }

        [DisplayName("Надпис/послание на кутията отгоре")]
        [DataType(DataType.Text)]
        public string TextOfBox { get; set; }

        [DisplayName("Надпис/и върху сладка/и")]
        [DataType(DataType.Text)]
        public string TextOfCookies { get; set; }

        [Required(ErrorMessage = "Попълни {0}")]
        [DisplayName("Дата за получаване")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfDecision { get; set; }

        [DisplayName("Адрес за получаване")]
        [DataType(DataType.Text)]
        public string ShippingAddress { get; set; }

        // This property will hold all available categories for selection
        public IEnumerable<SelectListItem> Categories { get; set; }

        // This property will hold all available appearances of orders for selection
        public IEnumerable<SelectListItem> Appearances { get; set; }
    }
}