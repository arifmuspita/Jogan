namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_ERROR_LIST", "MarkAsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_ERROR_LIST", "MarkAsDelete");
        }
    }
}
