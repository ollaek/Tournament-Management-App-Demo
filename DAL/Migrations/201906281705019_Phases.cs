namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        LegId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Legs", t => t.LegId, cascadeDelete: true)
                .Index(t => t.LegId);
            
            CreateTable(
                "dbo.TournamentPhases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(nullable: false),
                        PhaseId = c.Int(nullable: false),
                        PhaseOrder = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Phases", t => t.PhaseId, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId)
                .Index(t => t.PhaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentPhases", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentPhases", "PhaseId", "dbo.Phases");
            DropForeignKey("dbo.Phases", "LegId", "dbo.Legs");
            DropIndex("dbo.TournamentPhases", new[] { "PhaseId" });
            DropIndex("dbo.TournamentPhases", new[] { "TournamentId" });
            DropIndex("dbo.Phases", new[] { "LegId" });
            DropTable("dbo.TournamentPhases");
            DropTable("dbo.Phases");
            DropTable("dbo.Legs");
        }
    }
}
