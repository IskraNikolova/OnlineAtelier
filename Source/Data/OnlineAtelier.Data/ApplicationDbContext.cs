namespace OnlineAtelier.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;
    using Models.Models;
    using Models.Models.Comments;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<OrderComment> OrderComments { get; set; }

        public IDbSet<PublicationComment> PublicationComments { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Appearance> Appearances { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public IDbSet<PhotosOrder> UserPictures { get; set; }


        public IDbSet<Publication> Publications { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn =(DateTime?)DateTime.Now;
                }
            }
        }
    }
}