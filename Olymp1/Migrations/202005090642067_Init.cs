namespace Olymp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DeactivationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        FIO = c.String(nullable: false, maxLength: 250),
                        PhoneNumber = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Cards", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerId", "dbo.Cards");
            DropIndex("dbo.Customers", new[] { "CustomerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Cards");
        }
    }
}
