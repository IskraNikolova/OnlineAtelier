namespace OnlineAtelier.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        private IEnumerable<Picture> pictures;

        public Album()
        {
            this.pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Album Name")]
        public string AlbumName { get; set; }

        public virtual IEnumerable<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}