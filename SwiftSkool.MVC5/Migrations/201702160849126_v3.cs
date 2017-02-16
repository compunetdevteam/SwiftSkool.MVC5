namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Subjects", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Student_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.SubjectApplicationUsers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Payments", "Student_Id", c => c.Int());
            CreateIndex("dbo.Payments", "Student_Id");
            AddForeignKey("dbo.Payments", "Student_Id", "dbo.Students", "Id");
            DropColumn("dbo.Subjects", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "ApplicationUser_Id", c => c.Int());
            DropForeignKey("dbo.Payments", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubjectApplicationUsers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectStudents", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.SubjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SubjectApplicationUsers", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Student_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_Id" });
            DropIndex("dbo.Payments", new[] { "Student_Id" });
            DropColumn("dbo.Payments", "Student_Id");
            DropTable("dbo.SubjectApplicationUsers");
            DropTable("dbo.SubjectStudents");
            CreateIndex("dbo.Subjects", "ApplicationUser_Id");
            AddForeignKey("dbo.Subjects", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
