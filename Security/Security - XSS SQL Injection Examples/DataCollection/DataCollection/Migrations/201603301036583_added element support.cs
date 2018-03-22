namespace DataCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedelementsupport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        ElementId = c.Int(nullable: false, identity: true),
                        ElementType = c.String(),
                        NameAttribute = c.String(),
                        IdAttribute = c.String(),
                        ClassAttribute = c.String(),
                    })
                .PrimaryKey(t => t.ElementId);
            
            AddColumn("dbo.UserInputDatas", "Element_ElementId", c => c.Int());
            CreateIndex("dbo.UserInputDatas", "Element_ElementId");
            AddForeignKey("dbo.UserInputDatas", "Element_ElementId", "dbo.Elements", "ElementId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInputDatas", "Element_ElementId", "dbo.Elements");
            DropIndex("dbo.UserInputDatas", new[] { "Element_ElementId" });
            DropColumn("dbo.UserInputDatas", "Element_ElementId");
            DropTable("dbo.Elements");
        }
    }
}
