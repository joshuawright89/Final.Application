namespace Final.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFocusClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Focus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FocusLabel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Day", "FocusId", c => c.Int());
            CreateIndex("dbo.Day", "FocusId");
            AddForeignKey("dbo.Day", "FocusId", "dbo.Focus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Day", "FocusId", "dbo.Focus");
            DropIndex("dbo.Day", new[] { "FocusId" });
            DropColumn("dbo.Day", "FocusId");
            DropTable("dbo.Focus");
        }
    }
}
