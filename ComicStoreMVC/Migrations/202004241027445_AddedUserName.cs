namespace ComicStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
