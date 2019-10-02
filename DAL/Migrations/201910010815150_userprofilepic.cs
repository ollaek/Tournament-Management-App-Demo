namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofilepic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ProfilePicture");
        }
    }
}
