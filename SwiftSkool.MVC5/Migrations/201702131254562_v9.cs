namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectApplicationUsers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectApplicationUsers", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectApplicationUsers", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Subjects", "ApplicationUser_Id", c => c.Int());
            CreateIndex("dbo.Subjects", "ApplicationUser_Id");
            AddForeignKey("dbo.Subjects", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Students", "Subject_Id");
            DropTable("dbo.SubjectApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectApplicationUsers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.ApplicationUser_Id });
            
            AddColumn("dbo.Students", "Subject_Id", c => c.Int());
            DropForeignKey("dbo.Subjects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Subjects", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Subjects", "ApplicationUser_Id");
            CreateIndex("dbo.SubjectApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.SubjectApplicationUsers", "Subject_Id");
            CreateIndex("dbo.Students", "Subject_Id");
            AddForeignKey("dbo.SubjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectApplicationUsers", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
