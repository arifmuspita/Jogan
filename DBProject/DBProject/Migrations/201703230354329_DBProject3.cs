namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.M_ERROR_LIST", "A");
        }
        
        public override void Down()
        {
            AddColumn("dbo.M_ERROR_LIST", "A", c => c.String());
        }
    }
}
