using ASP.NET_Project.Models;

namespace ASP.NET_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASP.NET_Project.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASP.NET_Project.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(x => x.Id, 
                new Brand(){ Id = 1, Description = "HERMES", Name = "HERMES" },
                new Brand(){ Id = 2, Description = "CHANEL", Name = "CHANEL" },
                new Brand(){ Id = 3, Description = "RALPH LAUREN", Name = "RALPH LAUREN" },
                new Brand(){ Id = 4, Description = "PRADA", Name = "PRADA" }
            );
            context.Categories.AddOrUpdate(x => x.Id, 
                new Category() { Id = 1, Description = "Shoes", Name = "Shoes"},
                new Category() { Id = 2, Description = "Swimsuit", Name = "Swimsuit" },
                new Category() { Id = 3, Description = "Hat", Name = "Hat"},
                new Category() { Id = 4, Description = "Cloths", Name = "Cloths" }
            );
            context.Products.AddOrUpdate(x => x.Id,
                new Product() { Id = 1, BrandId = 1, CategoryId = 1, Description = "Shoes", InStoke = 10, Price = 1, Name = "Shoes",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 2, BrandId = 2, CategoryId = 2, Description = "Swimsuit", InStoke = 0, Price = 20, Name = "Swimsuit",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 3, BrandId = 3, CategoryId = 3, Description = "Hat", InStoke = 12, Price = 50, Name = "Hat",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 4, BrandId = 4, CategoryId = 4, Description = "Cloths", InStoke = 200, Price = 60, Name = "Cloths",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 5, BrandId = 1, CategoryId = 1, Description = "Shoes", InStoke = 30, Price = 4, Name = "Shoes",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 6, BrandId = 2, CategoryId = 2, Description = "Swimsuit", InStoke = 0, Price = 300, Name = "Swimsuit",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 7, BrandId = 3, CategoryId = 3, Description = "Hat", InStoke = 20, Price = 400, Name = "Hat",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 8, BrandId = 4, CategoryId = 4, Description = "Cloths", InStoke = 70, Price = 13, Name = "Cloths",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 9, BrandId = 1, CategoryId = 1, Description = "Shoes", InStoke = 0, Price = 2, Name = "Shoes",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 10, BrandId = 2, CategoryId = 2, Description = "Swimsuit", InStoke = 400, Price = 5, Name = "Swimsuit",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 11, BrandId = 3, CategoryId = 3, Description = "Hat", InStoke = 0, Price = 60, Name = "Hat",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 12, BrandId = 4, CategoryId = 4, Description = "Cloths", InStoke = 230, Price = 17, Name = "Cloths",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 13, BrandId = 1, CategoryId = 1, Description = "Shoes", InStoke = 0, Price = 21, Name = "Cloths",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 14, BrandId = 2, CategoryId = 2, Description = "Swimsuit", InStoke = 43, Price = 31, Name = "Swimsuit",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 15, BrandId = 3, CategoryId = 3, Description = "Hat", InStoke = 233, Price = 34, Name = "Hat",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                },    
                new Product() { Id = 16, BrandId = 4, CategoryId = 4, Description = "Cloths", InStoke = 65, Price = 23, Name = "Cloths",
                    Picture = "https://res.cloudinary.com/senbonzakura/image/upload/v1574465299/images/product/1833ad28-5a57-4037-8628-cd42be56d439_iovprj.jpg"
                }    
            );
        }
    }
}
