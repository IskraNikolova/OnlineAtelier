namespace OnlineAtelier.Models.Models
{
    using System.Collections.Generic;
    using Comments;

    public class Publication
    {
        private IEnumerable<PublicationComment> comments;

        public Publication()
        {
            this.comments = new HashSet<PublicationComment>();
        }

        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string PublicationText { get; set; }

        public IEnumerable<PublicationComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}