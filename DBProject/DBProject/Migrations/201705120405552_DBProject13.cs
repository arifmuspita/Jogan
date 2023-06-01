namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_BOOKING_STATION", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_BOOKING_STATION", "Status");
        }
    }
}
