using ProjectManagerApi.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.DataAccess.Repository
{
    public class UserDataAccess
    {
        /// <summary>
        /// Get all user data
        /// </summary>
        /// <returns></returns>
        public IList<User> GetAllUsers()
        {
            using (var context = new ProjectManagerDBContext())
            {
               return context.Users.ToList();
            }
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddNewUser(User user)
        {
            using (var context =  new ProjectManagerDBContext())
            {
                user = context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
        }

        /// <summary>
        /// Update existing user data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User UpdateUser(User user)
        {
            using (var context = new ProjectManagerDBContext())
            {
                user = context.Users.Attach(user);
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return user;
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>status</returns>
        public bool DeleteUser(User user)
        {
            using (var context = new ProjectManagerDBContext())
            {
                user = context.Users.FirstOrDefault(u => u.UserID == user.UserID);
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
        }
    }
}
