namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSimpleFieldsToContractor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contractors", "ShortName", c => c.String(maxLength: 100));
            AddColumn("dbo.Contractors", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Contractors", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Contractors", "TelephoneNo", c => c.String(maxLength: 100));
            AddColumn("dbo.Contractors", "Nip", c => c.String(maxLength: 20));
            AddColumn("dbo.Contractors", "Regon", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contractors", "Regon");
            DropColumn("dbo.Contractors", "Nip");
            DropColumn("dbo.Contractors", "TelephoneNo");
            DropColumn("dbo.Contractors", "Email");
            DropColumn("dbo.Contractors", "Description");
            DropColumn("dbo.Contractors", "ShortName");
        }
    }
}
