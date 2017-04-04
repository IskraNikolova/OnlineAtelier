namespace OnlineAtelier.Web.Models.ViewModels.ProfilePage
{
    using System;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class ProfileOrdersViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

        public int OrderId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AppearanceName { get; set; }

        public decimal AppearancePrice { get; set; }
    }
}