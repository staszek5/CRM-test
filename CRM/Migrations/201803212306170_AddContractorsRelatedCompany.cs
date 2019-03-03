namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractorsRelatedCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractorsRelatedCompanies",
                c => new
                    {
                        ContractorsRelationId = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContractorsRelationId)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.ContractorDependencyRelationships", t => t.ContractorsRelationId)
                .Index(t => t.ContractorsRelationId)
                .Index(t => t.ContractorId);
            
            AddColumn("dbo.ContractorDependencyRelationships", "ContractorsRelatedCompanyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractorsRelatedCompanies", "ContractorsRelationId", "dbo.ContractorDependencyRelationships");
            DropForeignKey("dbo.ContractorsRelatedCompanies", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.ContractorsRelatedCompanies", new[] { "ContractorId" });
            DropIndex("dbo.ContractorsRelatedCompanies", new[] { "ContractorsRelationId" });
            DropColumn("dbo.ContractorDependencyRelationships", "ContractorsRelatedCompanyId");
            DropTable("dbo.ContractorsRelatedCompanies");
        }
    }
}
