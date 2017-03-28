namespace OnlineAtelier.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Category
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
    }
}
