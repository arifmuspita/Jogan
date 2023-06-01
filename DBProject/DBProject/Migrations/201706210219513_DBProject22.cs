namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_ERROR_LIST", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_ERROR_LIST", "Description");
        }
    }
}
