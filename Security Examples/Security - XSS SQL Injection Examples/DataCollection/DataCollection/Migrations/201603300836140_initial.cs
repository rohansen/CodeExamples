namespace DataCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCookies",
                c => new
                    {
                        UserCookiesId = c.Int(nullable: false, identity: true),
                        Cookie = c.String(),
                    })
                .PrimaryKey(t => t.UserCookiesId);
            
            CreateTable(
                "dbo.UserInputDatas",
                c => new
                    {
                        UserInputDataId = c.Int(nullable: false, identity: true),
                        KeyStrokes = c.String(),
                        MousePositions = c.String(),
                        CollectedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserInputDataId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInputDatas");
            DropTable("dbo.UserCookies");
        }
    }
}
