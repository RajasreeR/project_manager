using ProjectManagerApi.Business;
using ProjectManagerApi.Entities.EntityModels;
using ProjectManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagerApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        TaskBo taskBusiness = new TaskBo();

        [HttpGet]
        [Route("api/tasks/getTasks")]
        public IEnumerable<TaskModel> GetTasks()
        {
            return taskBusiness.GetTasks();
        }

        [HttpGet]
        [Route("api/tasks/getParentTasks")]
        public IEnumerable<TaskModel> GetParentTasks()
        {
            return taskBusiness.GetParentTasks();
        }

        [HttpPost]
        [Route("api/tasks/update")]
        public TaskUpdateResponse CreateUpdateTask([FromBody] TaskModel taskdata)
        {
            TaskUpdateResponse response = new TaskUpdateResponse();
            response.Task = taskBusiness.AddUpdateTask(taskdata);
            response.Status = new Status() { Message = "Successfully created/update task", Result = true };
            return response;
        }
    }
}
