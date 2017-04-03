namespace OnlineAtelier.Web.Models.ProfilePageModels
{
    using System;
    using System.Collections.Generic;
    using OnlineAtelier.Models.Models;
    using OnlineAtelier.Models.Models.Comments;

    public class ProfileOrdersViewModel
    {
        private IEnumerable<byte[]> userPictures;
        private IEnumerable<Picture> galeryPictures;

        public ProfileOrdersViewModel()
        {
            this.userPictures = new List<byte[]>();
            this.galeryPictures = new List<Picture>();
        }

        public int Id { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

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

        public DateTime CreatedOn { get; set; }

        public string AppearanceName { get; set; }

        public decimal AppearancePrice { get; set; }
    }
}
