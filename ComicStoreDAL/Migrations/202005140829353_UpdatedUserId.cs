namespace ComicStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "UserId", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
        }
    }
}
