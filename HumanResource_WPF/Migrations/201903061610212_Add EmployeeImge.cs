namespace HumanResource_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeImge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Picture", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Picture");
        }
    }
}
