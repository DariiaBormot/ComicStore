namespace ComicStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
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
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComicBookId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        BookPrice = c.Double(nullable: false),
                        BookName = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComicBooks", t => t.ComicBookId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.ComicBookId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Appartment = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ComicBookId", "dbo.ComicBooks");
            DropForeignKey("dbo.ComicBooks", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ComicBookId", "dbo.ComicBooks");
            DropForeignKey("dbo.ComicBooks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ComicBookId" });
            DropIndex("dbo.ComicBooks", new[] { "PublisherId" });
            DropIndex("dbo.ComicBooks", new[] { "CategoryId" });
            DropIndex("dbo.Carts", new[] { "ComicBookId" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.ComicBooks");
            DropTable("dbo.Carts");
        }
    }
}
