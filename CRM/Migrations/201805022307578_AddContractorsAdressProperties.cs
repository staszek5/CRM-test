namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractorsAdressProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contractors", "Street", c => c.String(maxLength: 50));
            AddColumn("dbo.Contractors", "City", c => c.String(maxLength: 30));
            AddColumn("dbo.Contractors", "ZipCode", c => c.String(maxLength: 15));
            AddColumn("dbo.Contractors", "Province", c => c.String(maxLength: 50));
            AddColumn("dbo.Contractors", "AdressDetails", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contractors", "AdressDetails");
            DropColumn("dbo.Contractors", "Province");
            DropColumn("dbo.Contractors", "ZipCode");
            DropColumn("dbo.Contractors", "City");
            DropColumn("dbo.Contractors", "Street");
        }
    }
}
