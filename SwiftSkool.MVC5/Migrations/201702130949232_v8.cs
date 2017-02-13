namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.AspNetUsers", "StateId", "dbo.States");
            DropIndex("dbo.AspNetUsers", new[] { "StateId" });
            DropIndex("dbo.AspNetUsers", new[] { "SchoolId" });
            AddColumn("dbo.AspNetUsers", "HostelId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "StateId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "SchoolId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "StateId");
            CreateIndex("dbo.AspNetUsers", "SchoolId");
            CreateIndex("dbo.AspNetUsers", "HostelId");
            AddForeignKey("dbo.AspNetUsers", "HostelId", "dbo.Hostels", "Id");
            AddForeignKey("dbo.AspNetUsers", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.AspNetUsers", "StateId", "dbo.States", "Id");
            DropColumn("dbo.AspNetUsers", "LessonPlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LessonPlanId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "StateId", "dbo.States");
            DropForeignKey("dbo.AspNetUsers", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.AspNetUsers", "HostelId", "dbo.Hostels");
            DropIndex("dbo.AspNetUsers", new[] { "HostelId" });
            DropIndex("dbo.AspNetUsers", new[] { "SchoolId" });
            DropIndex("dbo.AspNetUsers", new[] { "StateId" });
            AlterColumn("dbo.AspNetUsers", "SchoolId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "StateId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "HostelId");
            CreateIndex("dbo.AspNetUsers", "SchoolId");
            CreateIndex("dbo.AspNetUsers", "StateId");
            AddForeignKey("dbo.AspNetUsers", "StateId", "dbo.States", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
        }
    }
}
