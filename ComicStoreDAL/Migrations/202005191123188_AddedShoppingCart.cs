namespace ComicStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShoppingCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartDALs",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ComicBookId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.ComicBooks", t => t.ComicBookId, cascadeDelete: true)
                .Index(t => t.ComicBookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartDALs", "ComicBookId", "dbo.ComicBooks");
            DropIndex("dbo.CartDALs", new[] { "ComicBookId" });
            DropTable("dbo.CartDALs");
        }
    }
}
