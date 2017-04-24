namespace The_People_Search.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        Interests = c.String(),
                    })
                .PrimaryKey(t => t.FirstName);

            AddPrimaryKey("dbo.Person", "LastName");
        }
        
        public override void Down()
        {
            DropTable("dbo.Person");
        }
    }
}
