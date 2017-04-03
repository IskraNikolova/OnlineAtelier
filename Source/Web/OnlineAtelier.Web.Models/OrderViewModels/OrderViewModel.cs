namespace OnlineAtelier.Web.Models.OrderViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using OnlineAtelier.Models.Models;
    using System.Web.Mvc;

    public class OrderViewModel 
    {
        private IEnumerable<byte[]> userPictures;
        private IEnumerable<Picture> galeryPictures;

        public OrderViewModel()
        {
            this.userPictures = new List<byte[]>();
            this.galeryPictures = new List<Picture>();
        }

        public int Id { get; set; }
        public string Appearance { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

        // This property will hold all available categories for selection
        public IEnumerable<SelectListItem> Categories { get; set; }

        // This property will hold all available appearances of orders for selection
        public IEnumerable<SelectListItem> Appearances { get; set; }

        [Display(Name = "UserPictures")]
        public IEnumerable<byte[]> UserPictures
        {
            get { return this.userPictures; }
            set { this.userPictures = value; }
        }

        public IEnumerable<Picture> GaleryPictures
        {
            get { return this.galeryPictures; }
            set { this.galeryPictures = value; }
        }
    }
}
