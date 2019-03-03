namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTaskType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTaskTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTaskTypes");
        }
    }
}
