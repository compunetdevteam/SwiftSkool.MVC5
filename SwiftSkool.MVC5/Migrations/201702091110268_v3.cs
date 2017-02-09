namespace SwiftSkool.MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guardians", "PhoneNumber", c => c.String());
            DropColumn("dbo.Guardians", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guardians", "AddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Guardians", "PhoneNumber");
        }
    }
}
