namespace comeagua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Guests", "EventID", "dbo.Events");
            DropForeignKey("dbo.Operations", "WeekID", "dbo.Weeks");
            DropForeignKey("dbo.Operations", "PubID", "dbo.Pubs");
            DropForeignKey("dbo.Photos", "PubID", "dbo.Pubs");
            DropForeignKey("dbo.Reviews", "PubID", "dbo.Pubs");
            DropForeignKey("dbo.TagPubs", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.TagPubs", "Pub_ID", "dbo.Pubs");
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropForeignKey("dbo.Photos", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.Events", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Guests", new[] { "EventID" });
            DropIndex("dbo.Operations", new[] { "WeekID" });
            DropIndex("dbo.Operations", new[] { "PubID" });
            DropIndex("dbo.Photos", new[] { "PubID" });
            DropIndex("dbo.Photos", new[] { "User_ID" });
            DropIndex("dbo.Pubs", new[] { "ReviewID" });
            DropIndex("dbo.Reviews", new[] { "PubID" });
            DropIndex("dbo.TagPubs", new[] { "Tag_ID" });
            DropIndex("dbo.TagPubs", new[] { "Pub_ID" });
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Error = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            AddColumn("dbo.Events", "Hour", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Code", c => c.String());
            AddColumn("dbo.Events", "AspNetUserID", c => c.String());
            AddColumn("dbo.Pubs", "ImagePath", c => c.String());
            DropColumn("dbo.Events", "Name");
            DropColumn("dbo.Events", "Private");
            DropColumn("dbo.Events", "UserID");
            DropColumn("dbo.Events", "ApplicationUser_Id");
            DropColumn("dbo.Pubs", "ReviewID");     
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagPubs",
                c => new
                    {
                        Tag_ID = c.Int(nullable: false),
                        Pub_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.Pub_ID });
            
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
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Commentary = c.String(),
                        Raiting = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        PubID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        PubID = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartHour = c.DateTime(nullable: false),
                        EndHour = c.DateTime(nullable: false),
                        WeekID = c.Int(nullable: false),
                        PubID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
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
            
            AddColumn("dbo.Pubs", "ReviewID", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Private", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "Name", c => c.String());
            DropForeignKey("dbo.ApplicationUserEvents", "Event_ID", "dbo.Events");
            DropForeignKey("dbo.ApplicationUserEvents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserEvents", new[] { "Event_ID" });
            DropIndex("dbo.ApplicationUserEvents", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Pubs", "ImagePath");
            DropColumn("dbo.Events", "AspNetUserID");
            DropColumn("dbo.Events", "Code");
            DropColumn("dbo.Events", "Date");
            DropColumn("dbo.Events", "Hour");
            DropTable("dbo.ApplicationUserEvents");
            DropTable("dbo.ErrorLogs");
            CreateIndex("dbo.TagPubs", "Pub_ID");
            CreateIndex("dbo.TagPubs", "Tag_ID");
            CreateIndex("dbo.Reviews", "PubID");
            CreateIndex("dbo.Pubs", "ReviewID", unique: true);
            CreateIndex("dbo.Photos", "User_ID");
            CreateIndex("dbo.Photos", "PubID");
            CreateIndex("dbo.Operations", "PubID");
            CreateIndex("dbo.Operations", "WeekID");
            CreateIndex("dbo.Guests", "EventID");
            CreateIndex("dbo.Events", "ApplicationUser_Id");
            CreateIndex("dbo.Events", "UserID");
            AddForeignKey("dbo.Events", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Photos", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Events", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TagPubs", "Pub_ID", "dbo.Pubs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TagPubs", "Tag_ID", "dbo.Tags", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "PubID", "dbo.Pubs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Photos", "PubID", "dbo.Pubs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Operations", "PubID", "dbo.Pubs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Operations", "WeekID", "dbo.Weeks", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Guests", "EventID", "dbo.Events", "ID", cascadeDelete: true);
        }
    }
}
