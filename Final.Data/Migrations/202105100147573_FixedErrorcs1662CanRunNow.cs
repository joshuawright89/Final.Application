namespace Final.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedErrorcs1662CanRunNow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Day", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Day", "OwnerId");
        }
    }
}
