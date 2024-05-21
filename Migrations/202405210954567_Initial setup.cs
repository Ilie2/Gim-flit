namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Last_name = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Number_of_phone = c.String(),
                        Role = c.Int(nullable: false),
                        Subscription_ID = c.Int(),
                        CourseSchedule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subscription", t => t.Subscription_ID)
                .ForeignKey("dbo.CourseSchedule", t => t.CourseSchedule_ID)
                .Index(t => t.Subscription_ID)
                .Index(t => t.CourseSchedule_ID);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        Description = c.String(),
                        Capacity = c.Int(nullable: false),
                        Trainer_ID = c.Int(),
                        Subscription_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trainer", t => t.Trainer_ID)
                .ForeignKey("dbo.Subscription", t => t.Subscription_ID)
                .Index(t => t.Trainer_ID)
                .Index(t => t.Subscription_ID);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Last_name = c.String(),
                        Age = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Photo = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Number_of_phone = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseSchedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ClientNo = c.Int(nullable: false),
                        ScheduledCourse_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.ScheduledCourse_ID)
                .Index(t => t.ScheduledCourse_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseSchedule", "ScheduledCourse_ID", "dbo.Course");
            DropForeignKey("dbo.Client", "CourseSchedule_ID", "dbo.CourseSchedule");
            DropForeignKey("dbo.Client", "Subscription_ID", "dbo.Subscription");
            DropForeignKey("dbo.Course", "Subscription_ID", "dbo.Subscription");
            DropForeignKey("dbo.Course", "Trainer_ID", "dbo.Trainer");
            DropIndex("dbo.CourseSchedule", new[] { "ScheduledCourse_ID" });
            DropIndex("dbo.Course", new[] { "Subscription_ID" });
            DropIndex("dbo.Course", new[] { "Trainer_ID" });
            DropIndex("dbo.Client", new[] { "CourseSchedule_ID" });
            DropIndex("dbo.Client", new[] { "Subscription_ID" });
            DropTable("dbo.CourseSchedule");
            DropTable("dbo.Trainer");
            DropTable("dbo.Course");
            DropTable("dbo.Subscription");
            DropTable("dbo.Client");
        }
    }
}
