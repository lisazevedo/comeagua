namespace comeagua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Guests", "EventID", "dbo.Events");
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropForeignKey("dbo.Photos", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.Events", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Guests", new[] { "EventID" });
            DropIndex("dbo.Photos", new[] { "User_ID" });
            CreateTable(
                "dbo.ApplicationUserEvents",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Event_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Event_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Event_ID);
            
            AddColumn("dbo.Events", "AspNetUserID", c => c.String());
            AddColumn("dbo.Events", "Hour", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Guests", "AspNetUserID", c => c.String());
            AddColumn("dbo.Pubs", "ImagePath", c => c.String());
            DropColumn("dbo.Events", "Name");
            DropColumn("dbo.Events", "Private");
            DropColumn("dbo.Events", "UserID");
            DropColumn("dbo.Events", "ApplicationUser_Id");
            DropColumn("dbo.Guests", "UserID");
            DropColumn("dbo.Photos", "User_ID");
            DropTable("dbo.Addresses");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(),
                        ReviewID = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        X = c.Int(nullable: false),
                        y = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                        Neighborhood = c.String(),
                        Number = c.Int(nullable: false),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Photos", "User_ID", c => c.Int());
            AddColumn("dbo.Guests", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Private", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "Name", c => c.String());
            DropForeignKey("dbo.ApplicationUserEvents", "Event_ID", "dbo.Events");
            DropForeignKey("dbo.ApplicationUserEvents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserEvents", new[] { "Event_ID" });
            DropIndex("dbo.ApplicationUserEvents", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Pubs", "ImagePath");
            DropColumn("dbo.Guests", "AspNetUserID");
            DropColumn("dbo.Events", "Date");
            DropColumn("dbo.Events", "Hour");
            DropColumn("dbo.Events", "AspNetUserID");
            DropTable("dbo.ApplicationUserEvents");
            CreateIndex("dbo.Photos", "User_ID");
            CreateIndex("dbo.Guests", "EventID");
            CreateIndex("dbo.Events", "ApplicationUser_Id");
            CreateIndex("dbo.Events", "UserID");
            AddForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Photos", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Events", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Guests", "EventID", "dbo.Events", "ID", cascadeDelete: true);
        }
    }
}
