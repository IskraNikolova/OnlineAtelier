﻿namespace OnlineAtelier.Models.Models
{
    using System;
    using Data.Common.Models;

    public class Image : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
