namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_JOGAN_HISTORY", "ObjectActivity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_JOGAN_HISTORY", "ObjectActivity");
        }
    }
}
