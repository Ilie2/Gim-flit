namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientupd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subscription", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subscription", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
