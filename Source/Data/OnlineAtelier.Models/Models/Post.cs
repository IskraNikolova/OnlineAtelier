namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using Comments;
    using Data.Common.Models;

    public class Post : IAuditInfo, IDeletableEntity
    {
        private ICollection<PostComment> comments;

        public Post()
        {
            this.comments = new HashSet<PostComment>();
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

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<PostComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}