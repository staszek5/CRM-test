namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteName = c.String(nullable: false, maxLength: 255),
                        NoteDescription = c.String(maxLength: 500),
                        ContractorId = c.Int(nullable: false),
                        ContractorEmployeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.ContractorEmployees", t => t.ContractorEmployeId)
                .Index(t => t.ContractorId)
                .Index(t => t.ContractorEmployeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "ContractorEmployeId", "dbo.ContractorEmployees");
            DropForeignKey("dbo.Notes", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.Notes", new[] { "ContractorEmployeId" });
            DropIndex("dbo.Notes", new[] { "ContractorId" });
            DropTable("dbo.Notes");
        }
    }
}
