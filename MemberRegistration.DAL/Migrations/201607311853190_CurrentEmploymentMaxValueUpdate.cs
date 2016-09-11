namespace MemberRegistration.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentEmploymentMaxValueUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "CurrentEmployment", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "CurrentEmployment", c => c.String(maxLength: 100));
        }
    }
}
