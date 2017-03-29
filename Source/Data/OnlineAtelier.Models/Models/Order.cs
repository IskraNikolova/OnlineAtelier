namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Comments;
    using Data.Common.Models;
    using Enums;

    public class Order: IAuditInfo, IDeletableEntity
    {
        private IEnumerable<byte[]> userPictures;
        private IEnumerable<Picture> galeryPictures;
        private IEnumerable<OrderComment> comments;

        public Order()
        {
            this.userPictures = new List<byte[]>();
            this.galeryPictures = new List<Picture>();
            this.comments = new HashSet<OrderComment>();
        }

        [Key]
        public int Id { get; set; }

        public SizeOfTheBox SizeOfTheBox { get; set; }

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