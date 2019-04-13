namespace ProjectManagerApi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentTasks",
                c => new
                    {
                        ParentTaskID = c.Long(nullable: false, identity: true),
                        ParentTask = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ParentTaskID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Long(nullable: false, identity: true),
                        Project = c.String(maxLength: 250),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Priority = c.Short(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Long(nullable: false, identity: true),
                        ParentTaskID = c.Long(),
                        ProjectID = c.Long(),
                        UserID = c.Long(),
                        Task = c.String(maxLength: 250),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Priority = c.Short(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.ParentTasks", t => t.ParentTaskID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.ParentTaskID)
                .Index(t => t.ProjectID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        EmployeeId = c.String(),
                        ProjectID = c.Long(),
                        TaskID = c.Long(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "ParentTaskID", "dbo.ParentTasks");
            DropIndex("dbo.Users", new[] { "ProjectID" });
            DropIndex("dbo.Tasks", new[] { "UserID" });
            DropIndex("dbo.Tasks", new[] { "ProjectID" });
            DropIndex("dbo.Tasks", new[] { "ParentTaskID" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.ParentTasks");
        }
    }
}
