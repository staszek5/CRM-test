namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProvinces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contractors", "ProvinceId", c => c.Int());
            CreateIndex("dbo.Contractors", "ProvinceId");
            AddForeignKey("dbo.Contractors", "ProvinceId", "dbo.Provinces", "Id");
            DropColumn("dbo.Contractors", "Province");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contractors", "Province", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Contractors", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Contractors", new[] { "ProvinceId" });
            DropColumn("dbo.Contractors", "ProvinceId");
            DropTable("dbo.Provinces");
        }
    }
}
