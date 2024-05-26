namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReparareInalll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainer", "Subscription_ID", c => c.Int());
            AddColumn("dbo.CourseSchedule", "Subscription_ID", c => c.Int());
            CreateIndex("dbo.Trainer", "Subscription_ID");
            CreateIndex("dbo.CourseSchedule", "Subscription_ID");
            AddForeignKey("dbo.Trainer", "Subscription_ID", "dbo.Subscription", "ID");
            AddForeignKey("dbo.CourseSchedule", "Subscription_ID", "dbo.Subscription", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseSchedule", "Subscription_ID", "dbo.Subscription");
            DropForeignKey("dbo.Trainer", "Subscription_ID", "dbo.Subscription");
            DropIndex("dbo.CourseSchedule", new[] { "Subscription_ID" });
            DropIndex("dbo.Trainer", new[] { "Subscription_ID" });
            DropColumn("dbo.CourseSchedule", "Subscription_ID");
            DropColumn("dbo.Trainer", "Subscription_ID");
        }
    }
}
