namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_NOISE_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_SORTER_RESULT", "Jig_ID", "dbo.M_JIG");
            DropIndex("dbo.T_NOISE_TEST_DATA_DETAIL", new[] { "Jig_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_STATUS", new[] { "Jig_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_DETAIL", new[] { "Jig_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_STATUS", new[] { "Jig_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_DETAIL", new[] { "Jig_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_STATUS", new[] { "Jig_ID" });
            DropIndex("dbo.T_SORTER_RESULT", new[] { "Jig_ID" });
            AlterColumn("dbo.T_NOISE_TEST_DATA_DETAIL", "Jig_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_NOISE_TEST_DATA_STATUS", "Jig_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "Jig_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_STATUS", "Jig_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_DETAIL", "Jig_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_STATUS", "Jig_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_SORTER_RESULT", "Jig_ID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_SORTER_RESULT", "Jig_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_STATUS", "Jig_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_SIGNAL_TEST_DATA_DETAIL", "Jig_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_STATUS", "Jig_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "Jig_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_NOISE_TEST_DATA_STATUS", "Jig_ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.T_NOISE_TEST_DATA_DETAIL", "Jig_ID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.T_SORTER_RESULT", "Jig_ID");
            CreateIndex("dbo.T_SIGNAL_TEST_DATA_STATUS", "Jig_ID");
            CreateIndex("dbo.T_SIGNAL_TEST_DATA_DETAIL", "Jig_ID");
            CreateIndex("dbo.T_RESISTANCE_TEST_DATA_STATUS", "Jig_ID");
            CreateIndex("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "Jig_ID");
            CreateIndex("dbo.T_NOISE_TEST_DATA_STATUS", "Jig_ID");
            CreateIndex("dbo.T_NOISE_TEST_DATA_DETAIL", "Jig_ID");
            AddForeignKey("dbo.T_SORTER_RESULT", "Jig_ID", "dbo.M_JIG", "Jig_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_SIGNAL_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG", "Jig_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_SIGNAL_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG", "Jig_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_RESISTANCE_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG", "Jig_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG", "Jig_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_NOISE_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG", "Jig_ID", cascadeDelete: true);
            AddForeignKey("dbo.T_NOISE_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG", "Jig_ID", cascadeDelete: true);
        }
    }
}
