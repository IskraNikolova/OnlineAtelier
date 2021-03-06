﻿namespace OnlineAtelier.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models.Models;
    using Models.Models.Comments;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IOnlineAtelierDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        
        public IDbSet<OrderComment> OrderComments { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<PostComment> PostComments { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Appearance> Appearances { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<PhotosOrder> UserPictures { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Figure> Figures { get; set; }

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
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}