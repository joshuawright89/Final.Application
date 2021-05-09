namespace Final.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstAfterInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDosForTheDay", "DayId", "dbo.Day");
            DropPrimaryKey("dbo.Day");
            DropColumn("dbo.Day", "DayId");
            AddColumn("dbo.Day", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Day", "Id");
            AddForeignKey("dbo.ToDosForTheDay", "DayId", "dbo.Day", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Day", "DayId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ToDosForTheDay", "DayId", "dbo.Day");
            DropPrimaryKey("dbo.Day");
            DropColumn("dbo.Day", "Id");
            AddPrimaryKey("dbo.Day", "DayId");
            AddForeignKey("dbo.ToDosForTheDay", "DayId", "dbo.Day", "Id", cascadeDelete: true);
        }
    }
}
