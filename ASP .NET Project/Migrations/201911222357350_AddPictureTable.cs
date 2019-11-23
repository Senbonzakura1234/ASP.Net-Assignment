namespace ASP.NET_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Picture", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Picture");
        }
    }
}
