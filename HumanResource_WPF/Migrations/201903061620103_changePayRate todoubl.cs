namespace HumanResource_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePayRatetodoubl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PayRate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "PayRate", c => c.String());
        }
    }
}
