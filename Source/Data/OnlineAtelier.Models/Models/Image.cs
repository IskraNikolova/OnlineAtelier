namespace OnlineAtelier.Models.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Configuration;
    using Data.Common.Models;

    public class Image : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual Category Category { get; set; }
    }
}
