namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractorsRelationType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractorsRelationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContractorDependencyRelationships", "ContractorsRelationTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContractorDependencyRelationships", "ContractorsRelationTypeId");
            AddForeignKey("dbo.ContractorDependencyRelationships", "ContractorsRelationTypeId", "dbo.ContractorsRelationTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractorDependencyRelationships", "ContractorsRelationTypeId", "dbo.ContractorsRelationTypes");
            DropIndex("dbo.ContractorDependencyRelationships", new[] { "ContractorsRelationTypeId" });
            DropColumn("dbo.ContractorDependencyRelationships", "ContractorsRelationTypeId");
            DropTable("dbo.ContractorsRelationTypes");
        }
    }
}
