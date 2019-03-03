namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToEmploee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractorEmployees", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContractorEmployees", "Description");
        }
    }
}
