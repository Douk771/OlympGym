namespace Olymp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VisitLogs", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitLogs", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
