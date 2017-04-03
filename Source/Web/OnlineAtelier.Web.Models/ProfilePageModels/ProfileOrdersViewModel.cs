namespace OnlineAtelier.Web.Models.ProfilePageModels
{
    using System;
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;

    public class ProfileOrdersViewModel
    {
        private IEnumerable<Picture> galeryPictures;

        public ProfileOrdersViewModel()
        {
            this.GaleryPictures = this.galeryPictures;
        }

        public int Id { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

        public int OrderId { get; set; }


        public IEnumerable<Picture> GaleryPictures
        {
            get { return this.galeryPictures; }
            set { this.galeryPictures = value; }
        }

        public DateTime CreatedOn { get; set; }

        public string AppearanceName { get; set; }

        public decimal AppearancePrice { get; set; }
    }
}
