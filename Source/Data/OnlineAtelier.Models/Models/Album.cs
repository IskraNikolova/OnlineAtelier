namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Common.Models;

    public class Album: IAuditInfo, IDeletableEntity
    {
        private ICollection<Publication> publications;

        public Album()
        {
            this.publications = new HashSet<Publication>();
        }

        [Key]
        public int Id { get; set; }

        public string AlbumName => this.Category.Name;

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Publication> Publications
        {
            get { return this.publications; }
            set { this.publications = value; }
        }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}