namespace The_People_Search.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Person");
            AddColumn("dbo.Person", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Person", "LastName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Person", new[] { "FirstName", "LastName" });
            DropColumn("dbo.Person", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "Name", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Person");
            DropColumn("dbo.Person", "LastName");
            DropColumn("dbo.Person", "FirstName");
            AddPrimaryKey("dbo.Person", "Name");
        }
    }
}
