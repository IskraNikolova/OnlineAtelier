namespace OnlineAtelier.Models.Models
{
    using System;
    using Data.Common.Models;

    public class Appearance : IAuditInfo, IDeletableEntity, IIdEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CookiesCount { get; set; }

        public bool IsBoxOfNormalSize { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
