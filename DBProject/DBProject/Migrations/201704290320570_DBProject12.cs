namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_MACHINE_BOOKING", "B_ID", "dbo.T_BOOKING_STATION");
            DropIndex("dbo.T_MACHINE_BOOKING", new[] { "B_ID" });
            DropColumn("dbo.T_MACHINE_BOOKING", "Booking_ID");
            RenameColumn(table: "dbo.T_MACHINE_BOOKING", name: "B_ID", newName: "Booking_ID");
            AlterColumn("dbo.T_MACHINE_BOOKING", "Booking_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.T_MACHINE_BOOKING", "Booking_ID");
            AddForeignKey("dbo.T_MACHINE_BOOKING", "Booking_ID", "dbo.T_BOOKING_STATION", "ID" );
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_MACHINE_BOOKING", "Booking_ID", "dbo.T_BOOKING_STATION");
            DropIndex("dbo.T_MACHINE_BOOKING", new[] { "Booking_ID" });
            AlterColumn("dbo.T_MACHINE_BOOKING", "Booking_ID", c => c.Int());
            RenameColumn(table: "dbo.T_MACHINE_BOOKING", name: "Booking_ID", newName: "B_ID");
            AddColumn("dbo.T_MACHINE_BOOKING", "Booking_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.T_MACHINE_BOOKING", "B_ID");
            AddForeignKey("dbo.T_MACHINE_BOOKING", "B_ID", "dbo.T_BOOKING_STATION", "ID");
        }
    }
}
