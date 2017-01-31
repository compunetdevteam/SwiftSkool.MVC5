namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LessonPlans", "Id", "dbo.Subjects");
            DropIndex("dbo.LessonPlans", new[] { "Id" });
            DropColumn("dbo.LessonPlans", "SubjectId");
            RenameColumn(table: "dbo.LessonPlans", name: "Id", newName: "SubjectId");
            AlterColumn("dbo.LessonPlans", "SubjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.LessonPlans", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.LessonPlans", "Id");
            CreateIndex("dbo.LessonPlans", "SubjectId");
            AddForeignKey("dbo.LessonPlans", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Subjects", "LessonPlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "LessonPlanId", c => c.Int());
            DropForeignKey("dbo.LessonPlans", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.LessonPlans", new[] { "SubjectId" });
            DropIndex("dbo.LessonPlans", new[] { "Id" });
            AlterColumn("dbo.LessonPlans", "SubjectId", c => c.Int());
            AlterColumn("dbo.LessonPlans", "SubjectId", c => c.Int(nullable: false, identity: true));
            RenameColumn(table: "dbo.LessonPlans", name: "SubjectId", newName: "Id");
            AddColumn("dbo.LessonPlans", "SubjectId", c => c.Int());
            CreateIndex("dbo.LessonPlans", "Id");
            AddForeignKey("dbo.LessonPlans", "Id", "dbo.Subjects", "Id");
        }
    }
}
