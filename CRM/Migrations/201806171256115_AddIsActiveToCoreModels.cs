namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveToCoreModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractorBranches", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContractorDependencyRelatedCompanies", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContractorEmployees", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContractorOffers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContractorOfferTypes", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.EmployeeSignificances", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Notes", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserTasks", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserTaskTypes", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Provinces", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Provinces", "IsActive");
            DropColumn("dbo.UserTaskTypes", "IsActive");
            DropColumn("dbo.UserTasks", "IsActive");
            DropColumn("dbo.Notes", "IsActive");
            DropColumn("dbo.EmployeeSignificances", "IsActive");
            DropColumn("dbo.ContractorOfferTypes", "IsActive");
            DropColumn("dbo.ContractorOffers", "IsActive");
            DropColumn("dbo.ContractorEmployees", "IsActive");
            DropColumn("dbo.ContractorDependencyRelatedCompanies", "IsActive");
            DropColumn("dbo.ContractorBranches", "IsActive");
        }
    }
}
