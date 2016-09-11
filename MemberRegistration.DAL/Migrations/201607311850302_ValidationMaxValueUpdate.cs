namespace MemberRegistration.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationMaxValueUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Members", "WebSite", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "WebSite", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
    }
}
