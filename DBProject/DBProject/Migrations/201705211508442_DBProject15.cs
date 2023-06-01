namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.M_NG_CONFIG", "Box_Index", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.M_NG_CONFIG", "Box_Index");
        }
    }
}
