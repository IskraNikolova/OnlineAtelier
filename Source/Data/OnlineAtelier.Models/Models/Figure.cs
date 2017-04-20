namespace OnlineAtelier.Models.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;

    public class Figure : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}