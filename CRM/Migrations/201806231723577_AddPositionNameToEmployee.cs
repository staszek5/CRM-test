namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionNameToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractorEmployees", "Position", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContractorEmployees", "Position");
        }
    }
}
