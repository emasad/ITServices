namespace CustomerInfoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDBAdding : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
    }
}
