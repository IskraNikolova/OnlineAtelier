namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Data.Common.Models;

    public class Category : IAuditInfo, IDeletableEntity
    {
        private IEnumerable<Album> albums;

        public Category()
        {
            this.albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public virtual IEnumerable<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
