namespace comeagua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pubs", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pubs", "Address");
        }
    }
}
