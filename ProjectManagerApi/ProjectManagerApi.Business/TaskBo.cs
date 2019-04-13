using ProjectManagerApi.DataAccess.Entity;
using ProjectManagerApi.DataAccess.Repository;
using ProjectManagerApi.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.Business
{
    public class TaskBo
    {
        TaskDataAccess taskDao = new TaskDataAccess();
        ParentTaskDataAccess parentDao = new ParentTaskDataAccess();

        /// <summary>
        /// get All tasks
        /// </summary>
        /// <returns></returns>
        public IList<TaskModel> GetTasks()
        {
            return taskDao.GetTasks().Select(t => new TaskModel
            {
                TaskId = t.TaskID,
                TaskName = t.Task1,
                ProjectId = t.ProjectID,
                ProjectName = t.Projects?.ProjectName,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Priority = t.Priority,
                Status = t.Status.Equals("Active") ? true : false,
                ParentId = t.ParentTaskID,
                ParentName = t.ParentTasks?.ParentTask1,
                UserID = t.UserID,
                UserName = t.Users?.FirstName + " " + t.Users?.LastName
            }).ToList();
        }

        /// <summary>
        /// Get all parent tasks
        /// </summary>
        /// <returns></returns>
        public IList<TaskModel> GetParentTasks()
        {
            return parentDao.GetAllParentTasks().Select(t => new TaskModel
            {
                TaskId = t.ParentTaskID,
                TaskName = t.ParentTask1,
            }).ToList();
        }

        /// <summary>
        /// Add or update task, add parent task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public TaskModel AddUpdateTask(TaskModel task)
        {
            if (task.ParentId == null && task.UserID == null && task.StartDate == null && task.EndDate == null)
            {
                ParentTask parent = new ParentTask()
                {
                    ParentTask1 = task.TaskName
                };
                parent = parentDao.AddParentTask(parent);
                task.ParentId = parent.ParentTaskID;
            }

            var taskData = new DataAccess.Entity.Task()
            {
                Task1 = task.TaskName,
                EndDate = task.EndDate,
                StartDate = task.StartDate,
                Priority = task.Priority,
                ProjectID = task.ProjectId,
                ParentTaskID = task.ParentId,
                UserID = task.UserID,
                Status = task.Status == true ? "Active" : "Inactive"
            };
            if (task.TaskId == 0)
            {
                taskData = taskDao.AddNewTask(taskData);
                task.TaskId = taskData.TaskID;
            }
            else
            {
                taskData.TaskID = task.TaskId;
                taskData = taskDao.UPdateTask(taskData);
            }
            return task;
        }

    }
}
