namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Students", "StateId", "dbo.States");
            DropIndex("dbo.Students", new[] { "HostelId" });
            DropIndex("dbo.Students", new[] { "StateId" });
            AlterColumn("dbo.Students", "HostelId", c => c.Int());
            AlterColumn("dbo.Students", "MedicalHistoryId", c => c.Int());
            AlterColumn("dbo.Students", "StateId", c => c.Int());
            CreateIndex("dbo.Students", "HostelId");
            CreateIndex("dbo.Students", "StateId");
            AddForeignKey("dbo.Students", "HostelId", "dbo.Hostels", "Id");
            AddForeignKey("dbo.Students", "StateId", "dbo.States", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StateId", "dbo.States");
            DropForeignKey("dbo.Students", "HostelId", "dbo.Hostels");
            DropIndex("dbo.Students", new[] { "StateId" });
            DropIndex("dbo.Students", new[] { "HostelId" });
            AlterColumn("dbo.Students", "StateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "MedicalHistoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "HostelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "StateId");
            CreateIndex("dbo.Students", "HostelId");
            AddForeignKey("dbo.Students", "StateId", "dbo.States", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "HostelId", "dbo.Hostels", "Id", cascadeDelete: true);
        }
    }
}
