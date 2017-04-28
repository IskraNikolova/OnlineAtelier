namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;

    public class Category : IAuditInfo, IDeletableEntity, IIdEntity
    {
        private ICollection<Post> publications;
        private ICollection<Image> images;

        public Category()
        {
            this.publications = new HashSet<Post>();
            this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Post> Publications
        {
            get { return this.publications; }
            set { this.publications = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images= value; }
        }
    }
}