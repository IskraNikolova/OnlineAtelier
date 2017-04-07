namespace OnlineAtelier.Models.Models
{
    using System;
    using Data.Common.Models;

    public class UserPicture : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public byte[] UserPictures { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}