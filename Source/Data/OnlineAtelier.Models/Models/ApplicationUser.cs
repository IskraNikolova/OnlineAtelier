namespace OnlineAtelier.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Comments;
    using Data.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private IEnumerable<Order> orders;
        private IEnumerable<OrderComment> orderComments;
        private IEnumerable<PublicationComment> publicationComments;

        public ApplicationUser()
        {
            this.CreatedOn = DateTime.Now;
            this.orders = new HashSet<Order>();
            this.orderComments = new HashSet<OrderComment>();
            this.publicationComments = new HashSet<PublicationComment>();
        }
     
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public byte[] UserPhoto { get; set; }

        public virtual IEnumerable<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }

        public virtual IEnumerable<OrderComment> OrderComments
        {
            get { return this.orderComments; }
            set { this.orderComments = value; }
        }

        public virtual IEnumerable<PublicationComment> PublicationComments
        {
            get { return this.publicationComments; }
            set { this.publicationComments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}