namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_ERROR_LIST",
                c => new
                    {
                        Message_Code = c.String(nullable: false, maxLength: 50),
                        Message_Name = c.String(nullable: false, maxLength: 250),
                        Impact = c.String(nullable: false, maxLength: 250),
                        Created_User = c.String(maxLength: 200),
                        Created_Date = c.DateTime(),
                        Updated_User = c.String(maxLength: 200),
                        Updated_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Message_Code);
            
            CreateTable(
                "dbo.T_ERROR_LIST",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message_Code = c.String(maxLength: 50),
                        Hardware_ID = c.String(maxLength: 50),
                        Status = c.String(maxLength: 50),
                        Created_User = c.String(maxLength: 200),
                        Created_Date = c.DateTime(),
                        Updated_User = c.String(maxLength: 200),
                        Updated_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_ERROR_LIST", t => t.Message_Code)
                .Index(t => t.Message_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_ERROR_LIST", "Message_Code", "dbo.M_ERROR_LIST");
            DropIndex("dbo.T_ERROR_LIST", new[] { "Message_Code" });
            DropTable("dbo.T_ERROR_LIST");
            DropTable("dbo.M_ERROR_LIST");
        }
    }
}
