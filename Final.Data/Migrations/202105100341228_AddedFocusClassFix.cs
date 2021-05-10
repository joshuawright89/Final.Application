namespace Final.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFocusClassFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Day", "FocusId", "dbo.Focus");
            DropIndex("dbo.Day", new[] { "FocusId" });
            AlterColumn("dbo.Day", "FocusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Day", "FocusId");
            AddForeignKey("dbo.Day", "FocusId", "dbo.Focus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Day", "FocusId", "dbo.Focus");
            DropIndex("dbo.Day", new[] { "FocusId" });
            AlterColumn("dbo.Day", "FocusId", c => c.Int());
            CreateIndex("dbo.Day", "FocusId");
            AddForeignKey("dbo.Day", "FocusId", "dbo.Focus", "Id");
        }
    }
}
