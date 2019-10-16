namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class externalParty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "Provider", c => c.String());
            AddColumn("dbo.Admin", "UserProviderId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin", "UserProviderId");
            DropColumn("dbo.Admin", "Provider");
        }
    }
}
