namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameContractorEmployeeInNote : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notes", name: "ContractorEmployeId", newName: "ContractorEmployeeId");
            RenameIndex(table: "dbo.Notes", name: "IX_ContractorEmployeId", newName: "IX_ContractorEmployeeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Notes", name: "IX_ContractorEmployeeId", newName: "IX_ContractorEmployeId");
            RenameColumn(table: "dbo.Notes", name: "ContractorEmployeeId", newName: "ContractorEmployeId");
        }
    }
}
