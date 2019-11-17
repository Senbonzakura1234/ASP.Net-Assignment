namespace ASP.NET_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: true),
                        Description = c.String(nullable: false, unicode: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, unicode: true),
                        Email = c.String(nullable: false, unicode: false),
                        Phone = c.String(nullable: false, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        ConfirmPassword = c.String(nullable: false, unicode: false),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(unicode: true),
                        LastName = c.String(unicode: true),
                        Email = c.String(unicode: false),
                        Address = c.String(unicode: true),
                        Avatar = c.String(unicode: false),
                        Birthday = c.String(unicode: false),
                        Introduction = c.String(unicode: true),
                        Phone = c.String(unicode: false),
                        Gender = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Token = c.String(unicode: false),
                        SecretToken = c.String(unicode: false),
                        MemberId = c.Long(nullable: false),
                        CreatedTimeMls = c.Long(nullable: false),
                        UpdatedTimeMls = c.Long(nullable: false),
                        DeletedTimeMls = c.Long(nullable: false),
                        ExpiredTimeMls = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: true),
                        Description = c.String(nullable: false, unicode: true),
                        Price = c.Double(nullable: false),
                        InStoke = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SongId = c.Long(nullable: false),
                        Name = c.String(unicode: true),
                        Description = c.String(unicode: true),
                        Singer = c.String(unicode: true),
                        Author = c.String(unicode: true),
                        Thumbnail = c.String(unicode: false),
                        Link = c.String(unicode: false),
                        CreatedTimeMls = c.Long(nullable: false),
                        UpdatedTimeMls = c.Long(nullable: false),
                        DeletedTimeMls = c.Long(nullable: false),
                        ExpiredTimeMls = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.Songs");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Members");
            DropTable("dbo.Customers");
            DropTable("dbo.Brands");
        }
    }
}
