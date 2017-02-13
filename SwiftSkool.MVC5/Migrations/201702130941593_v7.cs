namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hostels", "TeacherId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hostels", "TeacherId", c => c.Int(nullable: false));
        }
    }
}
