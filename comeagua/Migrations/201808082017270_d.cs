namespace comeagua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "UserID", "dbo.Users");
            DropIndex("dbo.Photos", new[] { "UserID" });
            RenameColumn(table: "dbo.Photos", name: "UserID", newName: "User_ID");
            AddColumn("dbo.Events", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ReviewID", c => c.Int(nullable: false));
            AlterColumn("dbo.Photos", "User_ID", c => c.Int());
            CreateIndex("dbo.Events", "ApplicationUser_Id");
            CreateIndex("dbo.Photos", "User_ID");
            AddForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Photos", "User_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Photos", new[] { "User_ID" });
            DropIndex("dbo.Events", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Photos", "User_ID", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "ReviewID");
            DropColumn("dbo.Events", "ApplicationUser_Id");
            RenameColumn(table: "dbo.Photos", name: "User_ID", newName: "UserID");
            CreateIndex("dbo.Photos", "UserID");
            AddForeignKey("dbo.Photos", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
