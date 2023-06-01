namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_BOOKING_STATION", "ByPassTestNoise", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_BOOKING_STATION", "ByPassTestSignal", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_BOOKING_STATION", "ByPassTestResistance", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_BOOKING_STATION", "ByPassTestResistance");
            DropColumn("dbo.T_BOOKING_STATION", "ByPassTestSignal");
            DropColumn("dbo.T_BOOKING_STATION", "ByPassTestNoise");
        }
    }
}
