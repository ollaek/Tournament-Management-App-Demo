namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tourtypessss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TournamentsTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tournaments", "TournamentsTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Tournaments", "PrivatePassword", c => c.String());
            CreateIndex("dbo.Tournaments", "TournamentsTypeId");
            AddForeignKey("dbo.Tournaments", "TournamentsTypeId", "dbo.TournamentsTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "TournamentsTypeId", "dbo.TournamentsTypes");
            DropIndex("dbo.Tournaments", new[] { "TournamentsTypeId" });
            DropColumn("dbo.Tournaments", "PrivatePassword");
            DropColumn("dbo.Tournaments", "TournamentsTypeId");
            DropTable("dbo.TournamentsTypes");
        }
    }
}
