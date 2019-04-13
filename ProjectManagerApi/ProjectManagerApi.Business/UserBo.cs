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
    public class UserBo
    {
        UserDataAccess userRepo = new UserDataAccess();

        /// <summary>
        /// Add or update logic
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel AddUpdateUsers(UserModel user)
        {
            var userDataEntity = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmployeeId = user.EmployeeId,
                ProjectID = user.ProjectId,
                TaskID = user.TaskId
            };
            if (user.ID == 0)
            {
                userDataEntity = userRepo.AddNewUser(userDataEntity);
                user.ID = userDataEntity.UserID;
            }
            else
            {
                userDataEntity.UserID = user.ID;
                userDataEntity = userRepo.UpdateUser(userDataEntity);
            }
            return user;
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteUser(UserModel user)
        {
            var userDataEntity = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmployeeId = user.EmployeeId,
                ProjectID = user.ProjectId,
                TaskID = user.TaskId,
                UserID = user.ID
            };
            return userRepo.DeleteUser(userDataEntity);
        }

        /// <summary>
        /// Fetch all user data
        /// </summary>
        /// <returns></returns>
        public IList<UserModel> GetAllUsers()
        {
            return userRepo.GetAllUsers().Select(p => new UserModel()
            {
                ID = p.UserID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                EmployeeId = p.EmployeeId,
                ProjectId = p.ProjectID,
                TaskId = p.TaskID
            }).ToList();
        }
    }
}
