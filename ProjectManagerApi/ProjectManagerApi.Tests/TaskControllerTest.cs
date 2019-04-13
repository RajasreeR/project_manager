using NUnit.Framework;
using ProjectManagerApi.Controllers;
using ProjectManagerApi.Entities.EntityModels;
using System;
using System.Collections.Generic;

namespace ProjectManagerApi.Tests
{
    [TestFixture]
    public class TaskControllerTest
    {
        TaskController taskController = new TaskController();

        [Test]
        public void AddTask()
        {
            var model = new TaskModel();
            model.TaskName = "Test Task1";
            model.ProjectId = 1;            
            model.Priority = 10;
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(3);
            model.Status = true;
            var result = taskController.CreateUpdateTask(model);
            Assert.AreEqual(result.Status, "Success");
            Assert.IsNotNull(result.Task);


        }

        [Test]
        public void AddParentTask()
        {
            var model = new TaskModel();
            model.TaskName = "Test parent Task1";            
            var result = taskController.CreateUpdateTask(model);
            Assert.AreEqual(result.Status, "Success");
            Assert.IsNotNull(result.Task);


        }

        [Test]
        public void UpdateTask()
        {
            var model = new TaskModel();
            model.TaskName = "Test Task_update";
            model.ProjectId = 1;
            model.Priority = 10;
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(4);
            model.Status = true;
            var result = taskController.CreateUpdateTask(model);
            Assert.AreEqual(result.Status, "Success");
            Assert.IsNotNull(result.Task);


        }

        [Test]
        public void GetTasks()
        {

            var result = taskController.GetTasks();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(IEnumerable<TaskModel>), result);

        }

        [Test]
        public void GetParentTasks()
        {

            var result = taskController.GetParentTasks();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(IEnumerable<TaskModel>), result);

        }
    }
}

