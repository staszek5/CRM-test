namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 255),
                        TaskDescription = c.String(maxLength: 500),
                        ContractorId = c.Int(nullable: false),
                        ContractorEmployeId = c.Int(),
                        UserTaskTypeId = c.Int(nullable: false),
                        AddDate = c.DateTime(),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.ContractorEmployees", t => t.ContractorEmployeId)
                .ForeignKey("dbo.UserTaskTypes", t => t.UserTaskTypeId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.ContractorEmployeId)
                .Index(t => t.UserTaskTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "UserTaskTypeId", "dbo.UserTaskTypes");
            DropForeignKey("dbo.UserTasks", "ContractorEmployeId", "dbo.ContractorEmployees");
            DropForeignKey("dbo.UserTasks", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.UserTasks", new[] { "UserTaskTypeId" });
            DropIndex("dbo.UserTasks", new[] { "ContractorEmployeId" });
            DropIndex("dbo.UserTasks", new[] { "ContractorId" });
            DropTable("dbo.UserTasks");
        }
    }
}
