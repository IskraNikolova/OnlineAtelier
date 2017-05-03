namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Comments;
    using Data.Common.Models;

    public class Order: IAuditInfo, IDeletableEntity, IIdEntity
    {
        private ICollection<PhotosOrder> userPictures;
        private ICollection<OrderComment> comments;
        private ICollection<Figure> figures;

        public Order()
        {
            this.userPictures = new HashSet<PhotosOrder>();
            this.comments = new HashSet<OrderComment>();
            this.figures = new HashSet<Figure>();
        }
        
        [Key]
        public int Id { get; set; }

        public string Details { get; set; }

        public DateTime DateOfDecision { get; set; }

        public string ShippingAddress { get; set; }

        public string ColorOfBox { get; set; }

        public decimal FinalPrice { get; set; }

        public string TextOfBox { get; set; }

        public string TextOfCookies { get; set; }

        public bool IsExecuted { get; set; }

        public bool IsАccepted { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<PhotosOrder> UserPictures
        {
            get { return this.userPictures; }
            set { this.userPictures = value; }
        }

        public int AppearanceId { get; set; }

        public virtual Appearance Appearance { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Author")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<OrderComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Figure> Figures
        {
            get { return this.figures; }
            set { this.figures = value; }
        }
    }
}