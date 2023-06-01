namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_JOGAN_HISTORY",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastActivity = c.String(nullable: false),
                        Created_User = c.String(maxLength: 200),
                        Created_Date = c.DateTime(),
                        Updated_User = c.String(maxLength: 200),
                        Updated_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_JOGAN_HISTORY");
        }
    }
}
