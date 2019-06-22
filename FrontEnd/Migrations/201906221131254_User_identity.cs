namespace FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_identity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "UserRole");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserUserRole");
            RenameTable(name: "dbo.AspNetUsers", newName: "User");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogin");
            RenameColumn(table: "dbo.User", name: "Id", newName: "UserId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.User", name: "UserId", newName: "Id");
            RenameTable(name: "dbo.UserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.User", newName: "AspNetUsers");
            RenameTable(name: "dbo.UserUserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.UserRole", newName: "AspNetRoles");
        }
    }
}
