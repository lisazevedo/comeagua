namespace comeagua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Private = c.Boolean(nullable: false),
                        PubID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pubs", t => t.PubID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PubID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
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
                "dbo.Operations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartHour = c.DateTime(nullable: false),
                        EndHour = c.DateTime(nullable: false),
                        WeekID = c.Int(nullable: false),
                        PubID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Weeks", t => t.WeekID, cascadeDelete: true)
                .ForeignKey("dbo.Pubs", t => t.PubID, cascadeDelete: true)
                .Index(t => t.WeekID)
                .Index(t => t.PubID);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        UserID = c.Int(nullable: false),
                        PubID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pubs", t => t.PubID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PubID);
            
            CreateTable(
                "dbo.Pubs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReviewID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ReviewID, unique: true);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pubs", t => t.PubID, cascadeDelete: true)
                .Index(t => t.PubID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        ReviewID = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TagPubs",
                c => new
                    {
                        Tag_ID = c.Int(nullable: false),
                        Pub_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.Pub_ID })
                .ForeignKey("dbo.Tags", t => t.Tag_ID, cascadeDelete: true)
                .ForeignKey("dbo.Pubs", t => t.Pub_ID, cascadeDelete: true)
                .Index(t => t.Tag_ID)
                .Index(t => t.Pub_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "UserID", "dbo.Users");
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TagPubs", "Pub_ID", "dbo.Pubs");
            DropForeignKey("dbo.TagPubs", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "PubID", "dbo.Pubs");
            DropForeignKey("dbo.Photos", "PubID", "dbo.Pubs");
            DropForeignKey("dbo.Operations", "PubID", "dbo.Pubs");
            DropForeignKey("dbo.Events", "PubID", "dbo.Pubs");
            DropForeignKey("dbo.Operations", "WeekID", "dbo.Weeks");
            DropForeignKey("dbo.Guests", "EventID", "dbo.Events");
            DropIndex("dbo.TagPubs", new[] { "Pub_ID" });
            DropIndex("dbo.TagPubs", new[] { "Tag_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reviews", new[] { "PubID" });
            DropIndex("dbo.Pubs", new[] { "ReviewID" });
            DropIndex("dbo.Photos", new[] { "PubID" });
            DropIndex("dbo.Photos", new[] { "UserID" });
            DropIndex("dbo.Operations", new[] { "PubID" });
            DropIndex("dbo.Operations", new[] { "WeekID" });
            DropIndex("dbo.Guests", new[] { "EventID" });
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.Events", new[] { "PubID" });
            DropTable("dbo.TagPubs");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tags");
            DropTable("dbo.Reviews");
            DropTable("dbo.Pubs");
            DropTable("dbo.Photos");
            DropTable("dbo.Weeks");
            DropTable("dbo.Operations");
            DropTable("dbo.Holidays");
            DropTable("dbo.Guests");
            DropTable("dbo.Events");
            DropTable("dbo.Addresses");
        }
    }
}
