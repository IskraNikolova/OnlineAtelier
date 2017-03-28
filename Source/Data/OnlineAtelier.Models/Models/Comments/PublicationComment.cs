namespace OnlineAtelier.Models.Models.Comments
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class PublicationComment : Comment
    {
        [ForeignKey("Publication")]
        public int PublicationId { get; set; }

        public virtual Publication Publication{ get; set; }
    }
}
