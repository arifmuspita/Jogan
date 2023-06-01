namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject8 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.V_MESSAGE", "Message_Code", c => c.String());
            //AddColumn("dbo.V_MESSAGE", "Message_Name", c => c.String());
            //DropColumn("dbo.V_MESSAGE", "Error_Code");
            //DropColumn("dbo.V_MESSAGE", "Error_Name");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.V_MESSAGE", "Error_Name", c => c.String());
            //AddColumn("dbo.V_MESSAGE", "Error_Code", c => c.String());
            //DropColumn("dbo.V_MESSAGE", "Message_Name");
            //DropColumn("dbo.V_MESSAGE", "Message_Code");
        }
    }
}
