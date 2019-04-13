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
    public class UserControllerTest
    {
        UserController userController = new UserController();

        [Test]
        public void AddUser()
        {
            var model = new UserModel();
            model.FirstName = "Test";
            model.LastName = "user";
            model.EmployeeId = "EMP01";
            var result = userController.AddUpdateUser(model);
            Assert.AreEqual(result.Status, "Success");
            Assert.IsNotNull(result.User);


        }

        [Test]
        public void UpdateUser()
        {
            var model = new UserModel();
            model.ID = 1;            
            model.FirstName = "Test";
            model.LastName = "user1";
            model.EmployeeId = "EMP01";
            var result = userController.AddUpdateUser(model);
            Assert.AreEqual(result.Status, "Success");
            Assert.IsNotNull(result.User);


        }

        [Test]
        public void GetUsers()
        {

            var result = userController.GetUsers();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(IEnumerable<UserModel>), result);

        }
    }
}
