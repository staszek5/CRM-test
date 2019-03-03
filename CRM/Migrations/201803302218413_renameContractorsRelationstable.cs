namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameContractorsRelationstable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContractorDependencyRelationships", newName: "ContractorDependencyRelationships");
            RenameColumn(table: "dbo.ContractorsRelatedCompanies", name: "ContractorsRelationId", newName: "ContractorDependencyRelationshipsId");
            RenameIndex(table: "dbo.ContractorsRelatedCompanies", name: "IX_ContractorsRelationId", newName: "IX_ContractorDependencyRelationshipsId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ContractorsRelatedCompanies", name: "IX_ContractorDependencyRelationshipsId", newName: "IX_ContractorsRelationId");
            RenameColumn(table: "dbo.ContractorsRelatedCompanies", name: "ContractorDependencyRelationshipsId", newName: "ContractorsRelationId");
            RenameTable(name: "dbo.ContractorDependencyRelationships", newName: "ContractorDependencyRelationships");
        }
    }
}
