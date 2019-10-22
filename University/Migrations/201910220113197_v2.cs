namespace University.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.People", name: "First Name", newName: "FirstName");
            AddColumn("dbo.People", "Active", c => c.Boolean());
            AddColumn("dbo.OfficeAssignments", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfficeAssignments", "Active");
            DropColumn("dbo.People", "Active");
            RenameColumn(table: "dbo.People", name: "FirstName", newName: "First Name");
        }
    }
}
