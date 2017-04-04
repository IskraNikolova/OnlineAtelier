namespace OnlineAtelier.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Customer");
                manager.Create(role);
            }

            //context.Categories.AddOrUpdate(category => category.CategoryName, new Category[]
            //{
            //  new Category()
            //  {
            //      CategoryName = "Любов, любов за мен ти си всичко!",
            //  },
            //  new Category()
            //  {
            //      CategoryName = "Рожден ден",
            //  },
            //    new Category()
            //  {
            //      CategoryName = "Осми март",
            //  },
            //    new Category()
            //  {
            //      CategoryName = "Великден",
            //  },
            //       new Category()
            //  {
            //      CategoryName = "Коледаааа",
            //  },
            //    new Category()
            //  {
            //      CategoryName = "Кръщенета и други бебешки истории",
            //  },
            //    new Category()
            //  {
            //      CategoryName = "Други",
            //  },
            //});

            //context.Appearances.AddOrUpdate(a => a.Name, new Appearance[]
            //{
            //    new Appearance()
            //    {
            //        Name = "Кутия от 3бр.",
            //        Price = 17
            //    },
            //      new Appearance()
            //    {
            //        Name = "Кутия от 4бр.",
            //        Price = 20
            //    },
            //        new Appearance()
            //    {
            //        Name = "Кутия от 6бр.",
            //        Price = 25
            //    },
            //          new Appearance()
            //    {
            //        Name = "Кутия от 9бр.",
            //        Price = 30
            //    },
            //    new Appearance()
            //    {
            //        Name = "Кутия от 12бр.",
            //        Price = 35
            //    },
            //    new Appearance()
            //    {
            //        Name = "Кутия от 16бр.",
            //        Price = 45
            //    },
            //      new Appearance()
            //    {
            //        Name = "Кутия от 20бр.",
            //        Price = 55
            //    }
            //});
        }
    }
}