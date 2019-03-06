namespace HumanResource_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        ManagerID = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        Email = c.String(),
                        PayRate = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
