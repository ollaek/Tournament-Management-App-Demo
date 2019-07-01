namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class legs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phases", "LegId", "dbo.Legs");
            DropIndex("dbo.Phases", new[] { "LegId" });
            AddColumn("dbo.TournamentPhases", "LegId", c => c.Int(nullable: false));
            CreateIndex("dbo.TournamentPhases", "LegId");
            AddForeignKey("dbo.TournamentPhases", "LegId", "dbo.Legs", "Id", cascadeDelete: true);
            DropColumn("dbo.Phases", "LegId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phases", "LegId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TournamentPhases", "LegId", "dbo.Legs");
            DropIndex("dbo.TournamentPhases", new[] { "LegId" });
            DropColumn("dbo.TournamentPhases", "LegId");
            CreateIndex("dbo.Phases", "LegId");
            AddForeignKey("dbo.Phases", "LegId", "dbo.Legs", "Id", cascadeDelete: true);
        }
    }
}
