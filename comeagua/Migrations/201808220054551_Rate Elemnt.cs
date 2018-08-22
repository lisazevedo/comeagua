namespace comeagua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RateElemnt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pubs", "Rate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pubs", "Rate");
        }
    }
}
