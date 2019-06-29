namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codepath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "QRCodePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tournaments", "QRCodePath");
        }
    }
}
