namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.M_NG_CONFIG", "Box_Index", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.M_NG_CONFIG", "Box_Index", c => c.String(maxLength: 25));
        }
    }
}
