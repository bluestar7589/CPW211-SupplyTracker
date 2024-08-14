using SupplyTracker.Data;
using SupplyTracker.Models;
using SupplyTracker.Util;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers.Text;

namespace SupplyTracker.Databases
{
    internal class UserDB
    {
        /// <summary>
        /// This method grabs all users in the database
        /// </summary>
        /// <returns>Returns a list of all users in the database</returns>
        public static List<User> GetAllUsers()
        {
            using (SupplyTrackerContext context = new())
            {
                return context.Users.ToList();
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
                string salt = PasswordHasher.GenerateSalt();
                user.Salt = salt;

                // Hash the password for the first time and save it
                user.Password = PasswordHasher.HashPassword(user.Password, user.Salt);

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
                var existingUser = context.Users.Find(user.UserID);
                if (existingUser != null)
                {
                    existingUser.Username = user.Username;
                    existingUser.Password = PasswordHasher.HashPassword(user.Password, existingUser.Salt);
                    existingUser.Role = user.Role;
                    existingUser.LastDateLogin = user.LastDateLogin;

                    context.SaveChanges();
                }

            }
        }

        /// <summary>
        /// This method to delete the user from the database
        /// </summary>
        /// <param name="user"></param>
        public static void DeleteUser(User user)
        {
            using (SupplyTrackerContext context = new())
            {
                var existingUser = context.Users.Find(user.UserID);
                if (existingUser != null)
                {
                    context.Users.Remove(existingUser);
                    context.SaveChanges();
                }
            }
        }


        /// <summary>
        /// Once the Login button is pressed, this actuates 
        /// </summary>
        public User ?VerifyLogin(string username, string password)
        {
            using (var context = new SupplyTrackerContext())
            {
                // Search for the user with the username input
                var user = context.Users.SingleOrDefault(u => u.Username == username);

                // Check if the user is found
                if (user == null)
                {
                    return null;
                }

                // Check if the user's salt is null
                if (user.Salt == null)
                {
                    // If salt is null, we must generate one for the user
                    // before hashing the password
                    user.Salt = PasswordHasher.GenerateSalt();
                }

                var hashedPassword = PasswordHasher.HashPassword(password, user.Salt);

                // Compare the hashed password with the stored hash
                if (hashedPassword == user.Password)
                {
                    user.LastDateLogin = DateTime.Now;
                    context.SaveChanges();
                    return user; // Password is correct
                }
                else
                {
                    return null; // Password is incorrect
                }
            }

        }

        


    }
}
