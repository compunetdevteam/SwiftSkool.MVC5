namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "SubjectAverage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "SubjectAverage");
        }
    }
}
