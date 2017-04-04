namespace OnlineAtelier.Models.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;

    public class Picture : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Picture Name")]
        public string PictureName { get; set; }

        [Required]
        public string Url { get; set; }

        public string Details { get; set; }

        public virtual Album Album { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}