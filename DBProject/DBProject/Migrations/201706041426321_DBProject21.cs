namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_TRANSACTION_INPUT", "ApplyNoiseTest", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_TRANSACTION_INPUT", "ApplySignalTest", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_TRANSACTION_INPUT", "ApplyResistanceTest", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_TRANSACTION_INPUT", "ApplyResistanceTest");
            DropColumn("dbo.T_TRANSACTION_INPUT", "ApplySignalTest");
            DropColumn("dbo.T_TRANSACTION_INPUT", "ApplyNoiseTest");
        }
    }
}
