namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractorsRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractorDependencyRelationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .Index(t => t.ContractorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractorDependencyRelationships", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.ContractorDependencyRelationships", new[] { "ContractorId" });
            DropTable("dbo.ContractorDependencyRelationships");
        }
    }
}
