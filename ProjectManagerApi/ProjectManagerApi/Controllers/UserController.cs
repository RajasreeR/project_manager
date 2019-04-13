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
    public class UserController : ApiController
    {
        UserBo userBusiness = new UserBo();

        [HttpGet]
        [Route("api/users/get")]
        public IEnumerable<UserModel> GetUsers()
        {
            return userBusiness.GetAllUsers();
        }

        [HttpPost]
        [Route("api/users/update")]
        public UserUpdateResponse AddUpdateUser([FromBody] UserModel userData)
        {
            UserUpdateResponse response = new UserUpdateResponse();
            response.User = userBusiness.AddUpdateUsers(userData);
            response.Status =  new Status() { Message = "Successfully created/update user", Result = true };
            return response;
        }

        [HttpPost]
        [Route("api/users/delete")]
        public Status DeleteUserData([FromBody] UserModel userData)
        {
            bool result = userBusiness.DeleteUser(userData);
            return new Status { Result = result, Message = result ? "Deleted successfully" : "Failed" };
        }
    }
}
