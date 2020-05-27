namespace Olymp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupClasses",
                c => new
                    {
                        GroupClasseId = c.Int(nullable: false, identity: true),
                        GroupClasseName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GroupClasseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroupClasses");
        }
    }
}
