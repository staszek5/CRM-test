namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectTypoInUserTask : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserTasks", name: "ContractorEmployeId", newName: "ContractorEmployeeId");
            RenameIndex(table: "dbo.UserTasks", name: "IX_ContractorEmployeId", newName: "IX_ContractorEmployeeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserTasks", name: "IX_ContractorEmployeeId", newName: "IX_ContractorEmployeId");
            RenameColumn(table: "dbo.UserTasks", name: "ContractorEmployeeId", newName: "ContractorEmployeId");
        }
    }
}
