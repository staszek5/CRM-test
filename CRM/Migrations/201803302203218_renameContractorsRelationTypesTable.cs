namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameContractorsRelationTypesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContractorsRelationTypes", newName: "ContractorDependencyRelationshipTypes");
            RenameColumn(table: "dbo.ContractorDependencyRelationships", name: "ContractorsRelationTypeId", newName: "ContractorDependencyRelationshipTypeId");
            RenameIndex(table: "dbo.ContractorDependencyRelationships", name: "IX_ContractorsRelationTypeId", newName: "IX_ContractorDependencyRelationshipTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ContractorDependencyRelationships", name: "IX_ContractorDependencyRelationshipTypeId", newName: "IX_ContractorsRelationTypeId");
            RenameColumn(table: "dbo.ContractorDependencyRelationships", name: "ContractorDependencyRelationshipTypeId", newName: "ContractorsRelationTypeId");
            RenameTable(name: "dbo.ContractorDependencyRelationshipTypes", newName: "ContractorsRelationTypes");
        }
    }
}
