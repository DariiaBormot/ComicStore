namespace ComicStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCartName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CartDALs", newName: "Carts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Carts", newName: "CartDALs");
        }
    }
}
