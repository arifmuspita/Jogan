namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.M_ERROR_LIST", "A", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.M_ERROR_LIST", "A");
        }
    }
}
