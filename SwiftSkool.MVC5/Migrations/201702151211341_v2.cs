namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "HostelId", "dbo.Hostels");
            DropIndex("dbo.AspNetUsers", new[] { "HostelId" });
            AlterColumn("dbo.AspNetUsers", "HostelId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "HostelId");
            AddForeignKey("dbo.AspNetUsers", "HostelId", "dbo.Hostels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "HostelId", "dbo.Hostels");
            DropIndex("dbo.AspNetUsers", new[] { "HostelId" });
            AlterColumn("dbo.AspNetUsers", "HostelId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "HostelId");
            AddForeignKey("dbo.AspNetUsers", "HostelId", "dbo.Hostels", "Id", cascadeDelete: true);
        }
    }
}
