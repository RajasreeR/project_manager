using ProjectManagerApi.DataAccess.Entity;
using System.Data.Entity;

namespace ProjectManagerApi.DataAccess
{
    public class ProjectManagerDBContext: DbContext
    {
        public ProjectManagerDBContext() : base("ProjectManagerDBContext")
            {
        }

        public DbSet<Entity.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ParentTask> ParentTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}


