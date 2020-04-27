namespace ComicStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComicBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Image = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderComicBooks",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        ComicBook_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.ComicBook_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.ComicBooks", t => t.ComicBook_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.ComicBook_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComicBooks", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderComicBooks", "ComicBook_Id", "dbo.ComicBooks");
            DropForeignKey("dbo.OrderComicBooks", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ComicBooks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderComicBooks", new[] { "ComicBook_Id" });
            DropIndex("dbo.OrderComicBooks", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.ComicBooks", new[] { "PublisherId" });
            DropIndex("dbo.ComicBooks", new[] { "CategoryId" });
            DropTable("dbo.OrderComicBooks");
            DropTable("dbo.Publishers");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.ComicBooks");
            DropTable("dbo.Categories");
        }
    }
}
