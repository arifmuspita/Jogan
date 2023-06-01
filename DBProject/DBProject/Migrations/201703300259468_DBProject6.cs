namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_JOGAN_HISTORY", "Object_Activity", c => c.String(nullable: false));
            AddColumn("dbo.T_JOGAN_HISTORY", "Last_Activity", c => c.String(nullable: false));
            DropColumn("dbo.T_JOGAN_HISTORY", "ObjectActivity");
            DropColumn("dbo.T_JOGAN_HISTORY", "LastActivity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_JOGAN_HISTORY", "LastActivity", c => c.String(nullable: false));
            AddColumn("dbo.T_JOGAN_HISTORY", "ObjectActivity", c => c.String(nullable: false));
            DropColumn("dbo.T_JOGAN_HISTORY", "Last_Activity");
            DropColumn("dbo.T_JOGAN_HISTORY", "Object_Activity");
        }
    }
}
