namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_SORTER_SUMMARY", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropIndex("dbo.T_SORTER_SUMMARY", new[] { "PO_Number" });
            AddColumn("dbo.T_SORTER_SUMMARY", "Jig_ID", c => c.String(nullable: false));
            AlterColumn("dbo.T_SORTER_SUMMARY", "PO_Number", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.T_SORTER_SUMMARY", "PO_Number");
            AddForeignKey("dbo.T_SORTER_SUMMARY", "PO_Number", "dbo.T_TRANSACTION_INPUT", "PO_Number");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_SORTER_SUMMARY", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropIndex("dbo.T_SORTER_SUMMARY", new[] { "PO_Number" });
            AlterColumn("dbo.T_SORTER_SUMMARY", "PO_Number", c => c.String(maxLength: 50));
            DropColumn("dbo.T_SORTER_SUMMARY", "Jig_ID");
            CreateIndex("dbo.T_SORTER_SUMMARY", "PO_Number");
            AddForeignKey("dbo.T_SORTER_SUMMARY", "PO_Number", "dbo.T_TRANSACTION_INPUT", "PO_Number");
        }
    }
}
