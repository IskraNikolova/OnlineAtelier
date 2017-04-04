﻿namespace OnlineAtelier.Models.Models.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Common.Models;

    public class PublicationComment :  IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [ForeignKey("Publication")]
        public int PublicationId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey("Author")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
