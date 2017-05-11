namespace OnlineAtelier.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            AddRoles(context);
            AddCategories(context);
            AddAppearances(context);
            AddUsers(context);
            AddPosts(context);
            AddOrders(context);
        }

        private static void AddOrders(ApplicationDbContext context)
        {
            var user = context.Users.OrderByDescending(u => u.CreatedOn).FirstOrDefault();

            if (!context.Orders.Any())
            {
                context.Orders.AddOrUpdate(o => o.Id, new Order[]
                {
                    new Order()
                    {
                        ApplicationUserId = user.Id,
                        CreatedOn = DateTime.Now,
                        AppearanceId = 1,
                        CategoryId = 1,
                        Details = "Здравейте може ли да си поръчам една кутия от три броя меденки за моя приятел?",
                        DateOfDecision = new DateTime(2017, 09, 03),
                        ColorOfBox = "бордо",
                        TextOfBox = "Обичам те, Митко!",
                        TextOfCookies = "Завинаги заедно!",
                        ShippingAddress = "Варна, ул.27юли"
                    },
                    new Order()
                    {
                        ApplicationUserId = user.Id,
                        CreatedOn = DateTime.Now,
                        AppearanceId = 2,
                        CategoryId = 1,
                        Details = "Здравейте може ли да си поръчам една кутия от три броя меденки за моя приятел?",
                        DateOfDecision = new DateTime(2017, 09, 03),
                        ColorOfBox = "бордо",
                        TextOfBox = "Обичам те, Митко!",
                        TextOfCookies = "Завинаги заедно!",
                        ShippingAddress = "Варна, ул.27юли",
                        IsАccepted = true
                    },
                    new Order()
                    {
                        ApplicationUserId = user.Id,
                        CreatedOn = DateTime.Now,
                        AppearanceId = 1,
                        CategoryId = 1,
                        Details = "Здравейте може ли да си поръчам една кутия от три броя меденки за моя приятел?",
                        DateOfDecision = new DateTime(2017, 09, 03),
                        ColorOfBox = "бордо",
                        TextOfBox = "Обичам те, Митко!",
                        TextOfCookies = "Завинаги заедно!",
                        ShippingAddress = "Варна, ул.27юли"
                    },
                    new Order()
                    {
                        ApplicationUserId = user.Id,
                        CreatedOn = DateTime.Now,
                        AppearanceId = 2,
                        CategoryId = 1,
                        Details = "Здравейте може ли да си поръчам една кутия от три броя меденки за моя приятел?",
                        DateOfDecision = new DateTime(2017, 09, 03),
                        ColorOfBox = "бордо",
                        TextOfBox = "Обичам те, Митко!",
                        TextOfCookies = "Завинаги заедно!",
                        ShippingAddress = "Варна, ул.27юли",
                        IsАccepted = true
                    },
                    new Order()
                    {
                        ApplicationUserId = user.Id,
                        CreatedOn = DateTime.Now,
                        AppearanceId = 2,
                        CategoryId = 1,
                        Details = "Здравейте може ли да си поръчам една кутия от три броя меденки за моя приятел?",
                        DateOfDecision = new DateTime(2017, 09, 03),
                        ColorOfBox = "бордо",
                        TextOfBox = "Обичам те, Митко!",
                        TextOfCookies = "Завинаги заедно!",
                        ShippingAddress = "Варна, ул.27юли",
                        IsАccepted = true
                    }
                });
            }
        }

        private void AddUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@gmail.com", "123456", "System", "Administrator", "0878604567");
                this.CreateUser(context, "sis@yahoo.com", "123456", "Sisi", "Radeva", "0878699567");
                this.CreateUser(context, "dany@yahoo.com", "123456", "Dani", "Nikolov", "0899604567");
                this.AddUserToRole(context, "admin@gmail.com", "Admin");
                context.SaveChanges();
            }
            ;
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

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private static void AddPosts(ApplicationDbContext context)
        {
            if (!context.Posts.Any())
            {
                context.Posts.AddOrUpdate(post => post.Content, new Post[]
                {
                    new Post()
                    {
                        Title = "Любов",
                        Content = "Нашите любовни кутии носят Вашите съкровени послания ❤❤❤",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/18194993_1149717571803347_425286637521011080_n.jpg?oh=3725f623582c32ccf1e81b8f70c5ff36&oe=597D16D0",
                        },
                        CategoryId = 1
                    },
                    new Post()
                    {
                        Title = "Миньонска любов",
                        Content = "Кутия от 3бр на тема любов. Послание с миньони.",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/17362512_1106438066131298_6470967276101080260_n.jpg?oh=4b9694aceea07675bb46264217169f8e&oe=597E2B27",
                        },
                        CategoryId = 1,
                    },
                    new Post()
                    {
                        Title = "Моето бебе",
                        Content = "Колекция в екрю, лилаво и мента ",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/17264749_1098464750261963_3244396670686318874_n.jpg?oh=d2fcd6c5a8c2ddbb21b96260cd4a65c2&oe=597A124A",
                        },
                        CategoryId = 5
                    },
                    new Post()
                    {
                        Title = "Футболни истории",
                        Content = "Бля бля",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/18198225_1152066524901785_7209454714366099812_n.jpg?oh=77e640711d4311bbdafef672d4cb0af1&oe=598B6ACB",
                        },
                        CategoryId = 7
                    },
                    new Post()
                    {
                        Title = "Миньонска любов",
                        Content = "Кутия от 3бр на тема любов. Послание с миньони.",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/17362512_1106438066131298_6470967276101080260_n.jpg?oh=4b9694aceea07675bb46264217169f8e&oe=597E2B27",
                        },
                        CategoryId = 1,
                    },
                    new Post()
                    {
                        Title = "Моето бебе",
                        Content = "Колекция в екрю, лилаво и мента ",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/17264749_1098464750261963_3244396670686318874_n.jpg?oh=d2fcd6c5a8c2ddbb21b96260cd4a65c2&oe=597A124A",
                        },
                        CategoryId = 5
                    },
                    new Post()
                    {
                        Title = "Сватбени курабийки",
                        Content = "Game Over",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/18056720_1140182006090237_7239008033532809132_n.jpg?oh=8188bd04d4eee414bc91fddcfbf8fc6a&oe=59B7029D",
                        },
                        CategoryId = 7
                    },
                    new Post()
                    {
                        Title = "Jeremy?",
                        Content = "Вкусни сладки заа група Jeremy",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/16105779_1051141801660925_1016493136442012428_n.jpg?oh=a8783c11a1231fe5b570b0c44742820e&oe=5984463C",
                        },
                        CategoryId = 7,
                    },
                    new Post()
                    {
                        Title = "Мартеници",
                        Content = "Изяж мартеница",
                        CreatedOn = DateTime.Now,
                        Image = new Image()
                        {
                            Url =
                                "https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/16807518_1080802982028140_3861682887705903689_n.jpg?oh=ca2c99e8cb8f682e3dc8c3ba3b468ac4&oe=597BE577",
                        },
                        CategoryId = 6
                    },
                });
            }
        }

        private static void AddAppearances(ApplicationDbContext context)
        {
            if (!context.Appearances.Any())
            {
                context.Appearances.AddOrUpdate(a => a.Name, new Appearance[]
                {
                    new Appearance()
                    {
                        Name = "Кутия от 3бр.",
                        Price = 17,
                        CookiesCount = 3,
                        IsBoxOfNormalSize = true,
                        CreatedOn = DateTime.Now,
                    },
                    new Appearance()
                    {
                        Name = "Кутия от 4бр.",
                        Price = 20,
                        CookiesCount = 4,
                        IsBoxOfNormalSize = true,
                        CreatedOn = DateTime.Now,
                    },
                    new Appearance()
                    {
                        Name = "Кутия от 6бр.",
                        Price = 25,
                        CookiesCount = 6,
                        CreatedOn = DateTime.Now,
                    },
                    new Appearance()
                    {
                        Name = "Кутия от 9бр.",
                        Price = 30,
                        CookiesCount = 9,
                        IsBoxOfNormalSize = true,
                        CreatedOn = DateTime.Now,
                    },
                    new Appearance()
                    {
                        Name = "Кутия от 12бр.",
                        Price = 35,
                        CookiesCount = 12,
                        IsBoxOfNormalSize = true,
                        CreatedOn = DateTime.Now,
                    },
                    new Appearance()
                    {
                        Name = "Кутия от 16бр.",
                        Price = 45,
                        CookiesCount = 16,
                        IsBoxOfNormalSize = true,
                        CreatedOn = DateTime.Now,
                    },
                    new Appearance()
                    {
                        Name = "Кутия от 20бр.",
                        Price = 55,
                        CookiesCount = 20,
                        IsBoxOfNormalSize = true,
                        CreatedOn = DateTime.Now,
                    }
                });
            }
        }

        private static void AddCategories(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(category => category.Name, new Category[]
                {
                    new Category()
                    {
                        Name = "Любов, любов за мен ти си всичко!",
                        CreatedOn = DateTime.Now,
                    },
                    new Category()
                    {
                        Name = "Рожден ден",
                        CreatedOn = DateTime.Now,
                    },
                    new Category()
                    {
                        Name = "Великден",
                        CreatedOn = DateTime.Now,
                    },
                    new Category()
                    {
                        Name = "Коледаааа",
                        CreatedOn = DateTime.Now,
                    },
                    new Category()
                    {
                        Name = "Кръщенета и други бебешки истории",
                        CreatedOn = DateTime.Now,
                    },
                    new Category()
                    {
                        Name = "Баба Марта",
                        CreatedOn = DateTime.Now,
                    },
                    new Category()
                    {
                        Name = "Други",
                        CreatedOn = DateTime.Now,
                    },
                });
            }
        }

        private void CreateUser(ApplicationDbContext context,
           string email, string password, string firstName, string lastName, string phoneNumber)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };

            var userCreateResult = userManager.Create(user, password);

            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }
    }
}