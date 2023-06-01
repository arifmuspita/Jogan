namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_TRANSACTION_INPUT", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_TRANSACTION_INPUT", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_MASTER", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_MASTER", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_MASTER", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_TRANSACTION_LASER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_TRANSACTION_LASER", "User_ID", "dbo.M_USER");
            DropIndex("dbo.T_TRANSACTION_INPUT", new[] { "Device_ID" });
            DropIndex("dbo.T_TRANSACTION_INPUT", new[] { "User_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_MASTER", new[] { "Device_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_MASTER", new[] { "User_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_MASTER", new[] { "Device_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_MASTER", new[] { "User_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_MASTER", new[] { "Device_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_MASTER", new[] { "User_ID" });
            DropIndex("dbo.T_TRANSACTION_LASER", new[] { "Device_ID" });
            DropIndex("dbo.T_TRANSACTION_LASER", new[] { "User_ID" });
            AlterColumn("dbo.T_TRANSACTION_INPUT", "Device_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_TRANSACTION_INPUT", "User_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_NOISE_TEST_DATA_MASTER", "Device_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_NOISE_TEST_DATA_MASTER", "User_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_MASTER", "Device_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_MASTER", "User_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_MASTER", "Device_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_MASTER", "User_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_TRANSACTION_LASER", "Device_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_TRANSACTION_LASER", "User_ID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_TRANSACTION_LASER", "User_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_TRANSACTION_LASER", "Device_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_MASTER", "User_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_MASTER", "Device_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_MASTER", "User_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_MASTER", "Device_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_NOISE_TEST_DATA_MASTER", "User_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_NOISE_TEST_DATA_MASTER", "Device_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_TRANSACTION_INPUT", "User_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_TRANSACTION_INPUT", "Device_ID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.T_TRANSACTION_LASER", "User_ID");
            CreateIndex("dbo.T_TRANSACTION_LASER", "Device_ID");
            CreateIndex("dbo.T_SIGNAL_TEST_DATA_MASTER", "User_ID");
            CreateIndex("dbo.T_SIGNAL_TEST_DATA_MASTER", "Device_ID");
            CreateIndex("dbo.T_RESISTANCE_TEST_DATA_MASTER", "User_ID");
            CreateIndex("dbo.T_RESISTANCE_TEST_DATA_MASTER", "Device_ID");
            CreateIndex("dbo.T_NOISE_TEST_DATA_MASTER", "User_ID");
            CreateIndex("dbo.T_NOISE_TEST_DATA_MASTER", "Device_ID");
            CreateIndex("dbo.T_TRANSACTION_INPUT", "User_ID");
            CreateIndex("dbo.T_TRANSACTION_INPUT", "Device_ID");
            AddForeignKey("dbo.T_TRANSACTION_LASER", "User_ID", "dbo.M_USER", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_TRANSACTION_LASER", "Device_ID", "dbo.M_DEVICE", "Device_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_SIGNAL_TEST_DATA_MASTER", "User_ID", "dbo.M_USER", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_SIGNAL_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE", "Device_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_RESISTANCE_TEST_DATA_MASTER", "User_ID", "dbo.M_USER", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_RESISTANCE_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE", "Device_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_NOISE_TEST_DATA_MASTER", "User_ID", "dbo.M_USER", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_NOISE_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE", "Device_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_TRANSACTION_INPUT", "User_ID", "dbo.M_USER", "User_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_TRANSACTION_INPUT", "Device_ID", "dbo.M_DEVICE", "Device_ID", cascadeDelete: true);
        }
    }
}
