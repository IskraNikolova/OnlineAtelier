namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using Comments;
    using Data.Common.Models;

    public class Publication : IAuditInfo, IDeletableEntity
    {
        private ICollection<PublicationComment> comments;

        public Publication()
        {
            this.comments = new HashSet<PublicationComment>();
        }

        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual Album Album { get; set; }

        public virtual ICollection<PublicationComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}