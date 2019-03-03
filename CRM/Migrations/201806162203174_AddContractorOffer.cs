namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractorOffer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractorOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferName = c.String(),
                        OfferDesctiption = c.String(),
                        ContractorId = c.Int(nullable: false),
                        ContractorEmployeeId = c.Int(),
                        AddDate = c.DateTime(),
                        ExpirationDate = c.DateTime(),
                        AcceptanceDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.ContractorEmployees", t => t.ContractorEmployeeId)
                .Index(t => t.ContractorId)
                .Index(t => t.ContractorEmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractorOffers", "ContractorEmployeeId", "dbo.ContractorEmployees");
            DropForeignKey("dbo.ContractorOffers", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.ContractorOffers", new[] { "ContractorEmployeeId" });
            DropIndex("dbo.ContractorOffers", new[] { "ContractorId" });
            DropTable("dbo.ContractorOffers");
        }
    }
}
