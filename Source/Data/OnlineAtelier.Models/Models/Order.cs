namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Comments;
    using Data.Common.Models;

    public class Order: IAuditInfo, IDeletableEntity
    {
        private IEnumerable<UserPicture> userPictures;
        private IEnumerable<Picture> galeryPictures;
        private IEnumerable<OrderComment> comments;

        public Order()
        {
            this.userPictures = new HashSet<UserPicture>();
            this.galeryPictures = new List<Picture>();
            this.comments = new HashSet<OrderComment>();
        }

        [Key]
        public int Id { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }

        public DateTime DateOfDecision { get; set; }

        public string ShippingAddress { get; set; }

        public string ColorOfBox { get; set; }

        public string TextOfBox { get; set; }

        public string TextOfCookies { get; set; }

        public bool IsExecuted { get; set; }

        public bool IsАccepted { get; set; }

        public virtual IEnumerable<UserPicture> UserPictures
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

        public virtual Appearance Appearance { get; set; }

        [ForeignKey("Author")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual IEnumerable<OrderComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}