namespace OnlineAtelier.Web.Models.ViewModels.ProfilePage
{
    using System;

    public class ProfileOrdersViewModel
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