namespace CustomerInfoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBCreatedNewly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Address = c.String(nullable: false),
                        PostCode = c.Int(nullable: false),
                        Telephone = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 450),
                        ContactPersonName = c.String(nullable: false),
                        ContactPersonPositionId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesigName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.Customers", new[] { "Code" });
            DropTable("dbo.Regions");
            DropTable("dbo.Designations");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
