namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailAndTelToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractorEmployees", "Email", c => c.String());
            AddColumn("dbo.ContractorEmployees", "TelephoneNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContractorEmployees", "TelephoneNo");
            DropColumn("dbo.ContractorEmployees", "Email");
        }
    }
}
