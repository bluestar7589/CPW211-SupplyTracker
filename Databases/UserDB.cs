using SupplyTracker.Data;
using SupplyTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyTracker.Databases
{
    internal class UserDB
    {

        /// <summary>
        /// Create the UserDTO class to store the user information
        /// </summary>
        public class UserDTO
        {
            [DisplayName("User ID")]
            public int UserID { get; set; }

            [DisplayName("Username")]
            public string? Username { get; set; }

            [DisplayName("Password")]
            public string? Password { get; set; }

            [DisplayName("Role")]
            public string? Role { get; set; }

            [DisplayName("Last Login")]
            public DateTime? LastDateLogin { get; set; }
        }

        /// <summary>
        /// This method grabs all users in the database
        /// </summary>
        /// <returns>Returns a list of all users in the database</returns>
        public static List<UserDTO> GetAllUsers()
        {
            using (SupplyTrackerContext context = new())
            {
                var lstUser = from user in context.Users
                              select new UserDTO
                              {
                                  UserID = user.UserID,
                                  Username = user.Username,
                                  Password = user.Password,
                                  Role = user.Role,
                                  LastDateLogin = user.LastDateLogin
                              };
                return lstUser.ToList();
            }
        }
        /// <summary>
        /// This method adds a new user to the database
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user)
        {
            using (SupplyTrackerContext context = new())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This method to update the user information in the database
        /// </summary>
        /// <param name="user"></param>
        public static void UpdateUser(User user)
        {
            using (SupplyTrackerContext context = new())
            {
                context.Users.Update(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This method to delete the user from the database
        /// </summary>
        /// <param name="user"></param>
        public static void DeleteUser(User user)
        {
            using (SupplyTrackerContext context = new SupplyTrackerContext())
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Once the Login button is pressed, this actuates 
        /// </summary>
        public bool VerifyLogin(string username, string password)
        {
            using (var context = new SupplyTrackerContext())
            {
                // Search for the user with the username input
                var user = context.Users.SingleOrDefault(u => u.Username == username);

                // If the username is found and the password matches proceed
                if (user != null && user.Password == password)
                {
                    user.LastDateLogin = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                // If not, return false
                else
                {
                    return false;
                }
            }

        }


    }
}
