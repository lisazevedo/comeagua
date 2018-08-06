namespace comeagua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
