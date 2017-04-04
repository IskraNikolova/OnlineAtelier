namespace OnlineAtelier.Models.Models.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Common.Models;

    public class OrderComment : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public string Text { get; set; }

        [ForeignKey("Author")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}