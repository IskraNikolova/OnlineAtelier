namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System;
    using System.ComponentModel;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DisplayOrderVm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Details { get; set; }

        [DisplayName("Тема")]
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; }

        [DisplayName("Вид")]
        public string AppearanceName { get; set; }

        [DisplayName("Начална цена")]
        public decimal AppearancePrice { get; set; }

        [DisplayName("Цена")]
        public decimal FinalPrice { get; set; }

        [DisplayName("Дата за получаване")]
        public DateTime DateOfDecision { get; set; }

        public ApplicationUser Author { get; set; }

        public bool IsАccepted { get; set; }
    }
}