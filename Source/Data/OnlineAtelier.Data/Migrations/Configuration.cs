namespace OnlineAtelier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            AddRoles(context);

           // AddCategories(context);
           // AddPosts(context);
            //AddAppearances(context);
        }

        private static void AddRoles(ApplicationDbContext context)
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
        }

        private static void AddPosts(ApplicationDbContext context)
        {
            context.Posts.AddOrUpdate(new Post[]
            {
                new Post()
                {
                    Title = "Zdrasti",
                    Content = "Emi",
                    CreatedOn = DateTime.Now,
                    Image = new Image()
                    {
                        Url =
                            "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/17903339_1130144337094004_602623295519817319_n.jpg?oh=d6188664235c6c81161c1e34ecb3fd71&oe=594FE622",
                    },
                    CategoryId = 6
                },
                new Post()
                {
                    Title = "Zdrasti",
                    Content = "Emi",
                    CreatedOn = DateTime.Now,
                    Image = new Image()
                    {
                        Url =
                            "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/17903339_1130144337094004_602623295519817319_n.jpg?oh=d6188664235c6c81161c1e34ecb3fd71&oe=594FE622",
                    },
                    CategoryId = 6
                },
                new Post()
                {
                    Title = "Zdrasti",
                    Content = "Emi",
                    CreatedOn = DateTime.Now,
                    Image = new Image()
                    {
                        Url =
                            "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/17903339_1130144337094004_602623295519817319_n.jpg?oh=d6188664235c6c81161c1e34ecb3fd71&oe=594FE622",
                    },
                    CategoryId = 2
                },
            });
        }

        private static void AddAppearances(ApplicationDbContext context)
        {
            context.Appearances.AddOrUpdate(a => a.Name, new Appearance[]
            {
                new Appearance()
                {
                    Name = "Кутия от 3бр.",
                    Price = 17
                },
                new Appearance()
                {
                    Name = "Кутия от 4бр.",
                    Price = 20
                },
                new Appearance()
                {
                    Name = "Кутия от 6бр.",
                    Price = 25
                },
                new Appearance()
                {
                    Name = "Кутия от 9бр.",
                    Price = 30
                },
                new Appearance()
                {
                    Name = "Кутия от 12бр.",
                    Price = 35
                },
                new Appearance()
                {
                    Name = "Кутия от 16бр.",
                    Price = 45
                },
                new Appearance()
                {
                    Name = "Кутия от 20бр.",
                    Price = 55
                }
            });
        }

        private static void AddCategories(ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(category => category.Name, new Category[]
            {
                new Category()
                {
                    Name = "Любов, любов за мен ти си всичко!",
                },
                new Category()
                {
                    Name = "Рожден ден",
                },
                new Category()
                {
                    Name = "Осми март",
                },
                new Category()
                {
                    Name = "Великден",
                },
                new Category()
                {
                    Name = "Коледаааа",
                },
                new Category()
                {
                    Name = "Кръщенета и други бебешки истории",
                },
                new Category()
                {
                    Name = "Други",
                },
            });
        }
    }
}