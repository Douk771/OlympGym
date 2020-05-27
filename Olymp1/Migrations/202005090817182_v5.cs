namespace Olymp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupClassesJournals",
                c => new
                    {
                        ClassesId = c.Int(nullable: false, identity: true),
                        ClassesTime = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        GroupClasseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassesId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.GroupClasses", t => t.GroupClasseId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.GroupClasseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupClassesJournals", "GroupClasseId", "dbo.GroupClasses");
            DropForeignKey("dbo.GroupClassesJournals", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.GroupClassesJournals", new[] { "GroupClasseId" });
            DropIndex("dbo.GroupClassesJournals", new[] { "EmployeeId" });
            DropTable("dbo.GroupClassesJournals");
        }
    }
}
