namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContractorsRelatedCompanies", newName: "ContractorDependencyRelatedCompanies");
            AddColumn("dbo.ContractorDependencyRelationships", "ContractorDependencyRelatedCompanyId", c => c.Int(nullable: false));
            DropColumn("dbo.ContractorDependencyRelationships", "ContractorsRelatedCompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContractorDependencyRelationships", "ContractorsRelatedCompanyId", c => c.Int(nullable: false));
            DropColumn("dbo.ContractorDependencyRelationships", "ContractorDependencyRelatedCompanyId");
            RenameTable(name: "dbo.ContractorDependencyRelatedCompanies", newName: "ContractorsRelatedCompanies");
        }
    }
}
