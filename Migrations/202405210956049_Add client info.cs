namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addclientinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Sub", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "Sub");
        }
    }
}
