namespace ComicStoreDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "BookName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "BookName");
        }
    }
}
