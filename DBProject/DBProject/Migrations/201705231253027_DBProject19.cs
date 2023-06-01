namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject19 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.V_MESSAGE", "MarkAsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.V_MESSAGE", "MarkAsDelete");
        }
    }
}
