namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_ERROR_LIST", "Error_Code", "dbo.M_ERROR_LIST");
            DropIndex("dbo.T_ERROR_LIST", new[] { "Error_Code" });
            DropTable("dbo.M_ERROR_LIST");
            DropTable("dbo.T_ERROR_LIST");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.T_ERROR_LIST",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Error_Code = c.String(maxLength: 50),
                        Hardware_ID = c.String(maxLength: 50),
                        Status = c.String(maxLength: 50),
                        Created_User = c.String(maxLength: 200),
                        Created_Date = c.DateTime(),
                        Updated_User = c.String(maxLength: 200),
                        Updated_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.M_ERROR_LIST",
                c => new
                    {
                        Error_Code = c.String(nullable: false, maxLength: 50),
                        Error_Name = c.String(nullable: false, maxLength: 250),
                        Impact = c.String(nullable: false, maxLength: 250),
                        Created_User = c.String(maxLength: 200),
                        Created_Date = c.DateTime(),
                        Updated_User = c.String(maxLength: 200),
                        Updated_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Error_Code);
            
            CreateIndex("dbo.T_ERROR_LIST", "Error_Code");
            AddForeignKey("dbo.T_ERROR_LIST", "Error_Code", "dbo.M_ERROR_LIST", "Error_Code");
        }
    }
}
