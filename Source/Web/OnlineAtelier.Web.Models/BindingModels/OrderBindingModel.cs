namespace OnlineAtelier.Web.Models.BindingModels
{
    using System.Collections.Generic;
    using OnlineAtelier.Models.Enums;
    using OnlineAtelier.Models.Models;

    public class OrderBindingModel
    {
        private IEnumerable<byte[]> userPictures;
        private IEnumerable<Picture> galeryPictures;

        public OrderBindingModel()
        {
            this.userPictures = new List<byte[]>();
            this.galeryPictures = new List<Picture>();
        }

        public string Details { get; set; }

        public string Category { get; set; }

        public string Appearance { get; set; }

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