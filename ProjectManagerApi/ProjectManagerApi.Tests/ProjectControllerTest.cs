using NUnit.Framework;
using ProjectManagerApi.Controllers;
using ProjectManagerApi.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.Tests
{
    [TestFixture]
    public class ProjectControllerTest
    {
        ProjectController projectController = new ProjectController();

        [Test]
        public void AddProjects()
        {
            var model = new ProjectModel();
            model.Name = "Test_project";
            model.Priority = 1;
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(3);
            model.Status = "Active";
            var result = projectController.CreateUpdateProject(model);
            Assert.AreEqual(result.Status, "Success");
            Assert.IsNotNull(result.Project);


        }

        [Test]
        public void UpdateProject()
        {
            var model = new ProjectModel();
            model.Name = "Test_project_2";
            model.Priority = 1;
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(3);
            model.Status = "Active";
            model.ProjectID = 2;
            var result = projectController.CreateUpdateProject(model);
            Assert.AreEqual(result.Status, "Success");
            Assert.IsNotNull(result.Project);


        }

        [Test]
        public void GetProjects()
        {

            var result = projectController.GetAllProjects();        
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(IEnumerable<ProjectModel>), result);

        }
    }
}
