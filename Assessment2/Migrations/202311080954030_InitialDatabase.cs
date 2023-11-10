namespace Assessment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customs", "PlaceID", "dbo.Areas");
            DropIndex("dbo.Customs", new[] { "PlaceID" });
            AlterColumn("dbo.Customs", "PlaceID", c => c.Int());
            CreateIndex("dbo.Customs", "PlaceID");
            AddForeignKey("dbo.Customs", "PlaceID", "dbo.Areas", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customs", "PlaceID", "dbo.Areas");
            DropIndex("dbo.Customs", new[] { "PlaceID" });
            AlterColumn("dbo.Customs", "PlaceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customs", "PlaceID");
            AddForeignKey("dbo.Customs", "PlaceID", "dbo.Areas", "ID", cascadeDelete: true);
        }
    }
}
