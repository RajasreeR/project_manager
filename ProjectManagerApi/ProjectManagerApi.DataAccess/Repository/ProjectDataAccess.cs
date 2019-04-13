using ProjectManagerApi.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.DataAccess.Repository
{
    public class ProjectDataAccess
    {
        /// <summary>
        /// get all projects
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjectData()
        {
            using (var context = new ProjectManagerDBContext())
            {
                return context.Projects.ToList();
                //foreach (var item in projects)
                //{
                //    item.Users = context.Users.ToList();
                //    item.Tasks = context.Tasks.ToList();
                //}
                //return projects;
            }
        }

        /// <summary>
        /// add new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public Project AddNewProject(Project project)
        {
            using (var context = new ProjectManagerDBContext())
            {
                project = context.Projects.Add(project);
                context.SaveChanges();
                return project;
            }
        }

        /// <summary>
        /// Upadte project data
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public Project UpdatewProject(Project project)
        {
            using (var context = new ProjectManagerDBContext())
            {
                project = context.Projects.Attach(project);
                context.Entry(project).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return project;
            }

        }
    }
    }
