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
    public class ProjectBo
    {
        ProjectDataAccess dataAccess = new ProjectDataAccess();
        UserDataAccess userAccess = new UserDataAccess();
        TaskDataAccess taskAccess = new TaskDataAccess();

        public IList<ProjectModel> GetAllProjects()
        {
            var projectData = dataAccess.GetAllProjectData().ToList();
            var userData = userAccess.GetAllUsers().ToList();
            var taskData = taskAccess.GetTasks().ToList();
            var projectModelInfo = new List<ProjectModel>();
            foreach (var p in projectData)
            {
                var model = new ProjectModel();
                model.ProjectID = p.ProjectID;
                model.Priority = p.Priority;
                model.Name = p.ProjectName;
                model.StartDate = p.StartDate;
                model.EndDate = p.EndDate;
                model.ManagerId = userData.Any() ? (userData.FirstOrDefault(x => x.ProjectID == p.ProjectID) != null ? userData.FirstOrDefault(x => x.ProjectID == p.ProjectID).UserID : 0) : 0;
                model.ManagerName = userData.Any() && userData.FirstOrDefault(x => x.ProjectID == p.ProjectID) != null ? (userData.FirstOrDefault(x => x.ProjectID == p.ProjectID).FirstName + " " + userData.FirstOrDefault(x => x.ProjectID == p.ProjectID).LastName) : null;
                model.Status = p.Status;
               model.TaskCount = taskData.Any() ? taskData.Count(x => x.ProjectID == p.ProjectID) : 0;
                projectModelInfo.Add(model);
            }
            return projectModelInfo;
           
        }

        /// <summary>
        /// To update the project details to db
        /// </summary>
        /// <param name="oProj"></param>
        /// <returns></returns>
        public ProjectModel AddUpdateProject(ProjectModel projectModel)
        {
            Project project = new Project()
            {
                EndDate = projectModel.EndDate,
                Priority = projectModel.Priority,
                ProjectName = projectModel.Name,
                StartDate = projectModel.StartDate,
                Status = projectModel.Status

            };
            if (projectModel.ProjectID == 0)
            {
                project = dataAccess.AddNewProject(project);
                projectModel.ProjectID = project.ProjectID;
            }
            else
            {
                project.ProjectID = projectModel.ProjectID;
                project = dataAccess.UpdatewProject(project);
                projectModel.ProjectID = project.ProjectID;
            }
            if (projectModel.ManagerId != null && projectModel.Status.Equals("Active"))
            {
                UserDataAccess userRepo = new UserDataAccess();
                User user = userRepo.GetAllUsers().Where(p => p.UserID == projectModel.ManagerId).FirstOrDefault();
                if (user != null)
                {
                    user.ProjectID = projectModel.ProjectID;
                    userRepo.UpdateUser(user);
                }
                
            }
            return projectModel;

        }
    }
}
