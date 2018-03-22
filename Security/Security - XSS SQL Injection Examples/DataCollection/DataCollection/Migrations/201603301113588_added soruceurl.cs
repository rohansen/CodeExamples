namespace DataCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsoruceurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInputDatas", "SourceURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInputDatas", "SourceURL");
        }
    }
}
