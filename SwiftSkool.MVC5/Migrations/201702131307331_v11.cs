namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hostels", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Hostels", new[] { "Id" });
            AddColumn("dbo.Hostels", "Teacher", c => c.Int());
            DropColumn("dbo.Hostels", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hostels", "TeacherId", c => c.Int());
            DropColumn("dbo.Hostels", "Teacher");
            CreateIndex("dbo.Hostels", "Id");
            AddForeignKey("dbo.Hostels", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
