namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectStudents", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Payments", "Student_Id", "dbo.Students");
            DropIndex("dbo.Payments", new[] { "Student_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Student_Id" });
            AddColumn("dbo.Students", "Subject_Id", c => c.Int());
            AddColumn("dbo.Guardians", "OtherName", c => c.String());
            AddColumn("dbo.Results", "SubjectAverage", c => c.Double(nullable: false));
            CreateIndex("dbo.Students", "Subject_Id");
            AddForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects", "Id");
            DropColumn("dbo.Payments", "Student_Id");
            DropTable("dbo.SubjectStudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Student_Id });
            
            AddColumn("dbo.Payments", "Student_Id", c => c.Int());
            DropForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Students", new[] { "Subject_Id" });
            DropColumn("dbo.Results", "SubjectAverage");
            DropColumn("dbo.Guardians", "OtherName");
            DropColumn("dbo.Students", "Subject_Id");
            CreateIndex("dbo.SubjectStudents", "Student_Id");
            CreateIndex("dbo.SubjectStudents", "Subject_Id");
            CreateIndex("dbo.Payments", "Student_Id");
            AddForeignKey("dbo.Payments", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.SubjectStudents", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectStudents", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
