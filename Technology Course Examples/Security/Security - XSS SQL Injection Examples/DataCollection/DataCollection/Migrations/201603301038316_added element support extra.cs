namespace DataCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedelementsupportextra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Elements", "ElementTagName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Elements", "ElementTagName");
        }
    }
}
