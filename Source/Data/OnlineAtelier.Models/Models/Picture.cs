namespace OnlineAtelier.Models.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Picture Name")]
        public string PictureName { get; set; }

        [Required]
        public string Url { get; set; }

        public string Details { get; set; }

        public virtual Album Album { get; set; }
    }
}
