namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCooperationsTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cooperationtypes (CooperationTypeName) Values ('Klient')");
            Sql("INSERT INTO Cooperationtypes (CooperationTypeName) Values ('Partner')");
            Sql("INSERT INTO Cooperationtypes (CooperationTypeName) Values ('Dostawca')");
            Sql("INSERT INTO Cooperationtypes (CooperationTypeName) Values ('Konkurencja')");
        }
        
        public override void Down()
        {
        }
    }
}
