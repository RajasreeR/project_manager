using ProjectManagerApi.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerApi.DataAccess.Repository
{
    public class TaskDataAccess
    {
        /// <summary>
        /// Get list of tasks
        /// </summary>
        /// <returns></returns>
        public IList<Task> GetTasks()
        {
            using (var cntx = new ProjectManagerDBContext())
            {
                var taskList = cntx.Tasks.ToList();
                foreach (var item in taskList)
                {
                    item.ParentTasks = cntx.ParentTasks.FirstOrDefault(p => p.ParentTaskID == item.ParentTaskID);
                    item.Projects = cntx.Projects.FirstOrDefault(p => p.ProjectID == item.ProjectID);
                    item.Users = cntx.Users.FirstOrDefault(p => p.UserID == item.UserID);
                }
                return taskList;
            }

        }

        /// <summary>
        /// add new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Task AddNewTask(Task task)
        {
            using (var context = new ProjectManagerDBContext())
            {
                task = context.Tasks.Add(task);
                context.SaveChanges();
                return task;
            }
        }

        /// <summary>
        /// update the task data
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Task UPdateTask(Task task)
        {
            using (var context = new ProjectManagerDBContext())
            {
                task = context.Tasks.Attach(task);
                context.Entry(task).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return task;
            }
        }
    }
}
