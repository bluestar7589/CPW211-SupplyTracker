using System;
using System.Collections.Generic;
using SupplyTracker.Data; // Ensure we have the correct namespace for the DbContext

namespace SupplyTracker.Models;

public partial class User
{
    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// The username of the account login to system
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// The password of the account login to system
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// The role of the account login to system
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// The last date the user logged into the system
    /// </summary>
    public DateTime? LastDateLogin { get; set; }

    /// <summary>
    /// Displays true if login was successful, displays false if not
    /// </summary>
    public bool LoginAttempt { get; set; }
    /// <summary>
    /// Default the login attempt to false on user object creation
    /// </summary>
    public User()
    {
        LoginAttempt = false;
    }

    /// <summary>
    /// Once the Login button is pressed, this actuates 
    /// </summary>
    public bool VerifyLogin(string username, string password)
    {
        using (var context = new SupplyTrackerContext())
        {
            // Find 
            var user = context.Users.SingleOrDefault(u => u.Username == username);

            // If the username is found and the password matches proceed
            if (user != null && user.Password == password)
            {
                user.LastDateLogin = DateTime.Now;
                context.SaveChanges();
                LoginAttempt = true;
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




