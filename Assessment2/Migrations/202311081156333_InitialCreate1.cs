namespace Assessment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Areas", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customs", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customs", "Name", c => c.String());
            AlterColumn("dbo.Areas", "Name", c => c.String());
        }
    }
}
