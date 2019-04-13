using ProjectManagerApi.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.DataAccess.Repository
{
    public class ParentTaskDataAccess
    {
        /// <summary>
        /// get all parent tasks
        /// </summary>
        /// <returns></returns>
        public IList<ParentTask> GetAllParentTasks()
        {
            using (var context = new ProjectManagerDBContext())
            {
                return context.ParentTasks.ToList();
            }
        }

        /// <summary>
        /// Add new parent task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public ParentTask AddParentTask(ParentTask task)
        {
            using (var context = new ProjectManagerDBContext())
            {
                task = context.ParentTasks.Add(task);
                context.SaveChanges();
                return task;
            }
        }

        /// <summary>
        /// Update new parent task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public ParentTask UpdateParentTask(ParentTask task)
        {
            using (var context = new ProjectManagerDBContext())
            {
                task = context.ParentTasks.Attach(task);
                context.Entry(task).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return task;
            }
        }
    }
}
