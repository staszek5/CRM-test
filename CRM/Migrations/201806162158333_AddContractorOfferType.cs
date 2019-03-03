namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractorOfferType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractorOfferTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContractorOfferTypes");
        }
    }
}
