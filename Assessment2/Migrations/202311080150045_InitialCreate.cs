namespace Assessment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PlaceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.PlaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customs", "PlaceID", "dbo.Areas");
            DropIndex("dbo.Customs", new[] { "PlaceID" });
            DropTable("dbo.Customs");
            DropTable("dbo.Areas");
        }
    }
}
