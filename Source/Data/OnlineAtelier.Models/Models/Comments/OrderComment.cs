namespace OnlineAtelier.Models.Models.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Principal;
    using Data.Common.Models;

    public class OrderComment : IAuditInfo, IDeletableEntity, IIdEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey("Author")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}