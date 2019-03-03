namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCooperationTypeIdToNullableInCondtractor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contractors", "CooperationTypeId", "dbo.CooperationTypes");
            DropIndex("dbo.Contractors", new[] { "CooperationTypeId" });
            AlterColumn("dbo.Contractors", "CooperationTypeId", c => c.Int());
            CreateIndex("dbo.Contractors", "CooperationTypeId");
            AddForeignKey("dbo.Contractors", "CooperationTypeId", "dbo.CooperationTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contractors", "CooperationTypeId", "dbo.CooperationTypes");
            DropIndex("dbo.Contractors", new[] { "CooperationTypeId" });
            AlterColumn("dbo.Contractors", "CooperationTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contractors", "CooperationTypeId");
            AddForeignKey("dbo.Contractors", "CooperationTypeId", "dbo.CooperationTypes", "Id", cascadeDelete: true);
        }
    }
}
