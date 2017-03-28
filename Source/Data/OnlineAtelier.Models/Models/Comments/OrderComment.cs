namespace OnlineAtelier.Models.Models.Comments
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderComment : Comment
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
