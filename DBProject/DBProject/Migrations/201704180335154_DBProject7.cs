namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject7 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.V_ERROR_LIST", newName: "V_MESSAGE");
        }
        
        public override void Down()
        {
            //RenameTable(name: "dbo.V_MESSAGE", newName: "V_ERROR_LIST");
        }
    }
}
