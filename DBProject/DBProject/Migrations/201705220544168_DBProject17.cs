namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject17 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER", "Soak_Time", c => c.Int(nullable: false));
            //AddColumn("dbo.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER", "Measurement_Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER", "Measurement_Duration");
            //DropColumn("dbo.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER", "Soak_Time");
        }
    }
}
