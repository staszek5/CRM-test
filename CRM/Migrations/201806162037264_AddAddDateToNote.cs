namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddDateToNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "AddDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "AddDate");
        }
    }
}
