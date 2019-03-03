namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractorBranches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractorBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractorBranchName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contractors", "ContractorBranchId", c => c.Int());
            CreateIndex("dbo.Contractors", "ContractorBranchId");
            AddForeignKey("dbo.Contractors", "ContractorBranchId", "dbo.ContractorBranches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contractors", "ContractorBranchId", "dbo.ContractorBranches");
            DropIndex("dbo.Contractors", new[] { "ContractorBranchId" });
            DropColumn("dbo.Contractors", "ContractorBranchId");
            DropTable("dbo.ContractorBranches");
        }
    }
}
