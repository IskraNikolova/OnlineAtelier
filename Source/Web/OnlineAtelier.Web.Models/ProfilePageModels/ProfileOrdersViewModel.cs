namespace OnlineAtelier.Web.Models.ProfilePageModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using OnlineAtelier.Models.Models;
    using OnlineAtelier.Models.Models.Comments;

    public class ProfileOrdersViewModel
    {
        private IEnumerable<byte[]> userPictures;
        private IEnumerable<Picture> galeryPictures;
        private IEnumerable<OrderComment> comments;

        public ProfileOrdersViewModel()
        {
            this.userPictures = new List<byte[]>();
            this.galeryPictures = new List<Picture>();
            this.comments = new HashSet<OrderComment>();
        }

        public int Id { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

        public DateTime? DateOfDecision { get; set; }

        public bool IsExecuted { get; set; }

        public bool IsRefused { get; set; }

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

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public Appearance Appearance { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<OrderComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
