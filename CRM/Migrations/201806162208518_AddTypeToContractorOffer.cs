namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeToContractorOffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractorOffers", "ContractorOfferTypeId", c => c.Int());
            CreateIndex("dbo.ContractorOffers", "ContractorOfferTypeId");
            AddForeignKey("dbo.ContractorOffers", "ContractorOfferTypeId", "dbo.ContractorOfferTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractorOffers", "ContractorOfferTypeId", "dbo.ContractorOfferTypes");
            DropIndex("dbo.ContractorOffers", new[] { "ContractorOfferTypeId" });
            DropColumn("dbo.ContractorOffers", "ContractorOfferTypeId");
        }
    }
}
