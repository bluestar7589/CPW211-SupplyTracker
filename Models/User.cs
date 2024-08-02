using System;
using System.Collections.Generic;
using SupplyTracker.Data; // Ensure we have the correct namespace for the DbContext

namespace SupplyTracker.Models;

public partial class User
{
    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    public int UserID { get; set; }

    /// <summary>
    /// The username of the account login to system
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// The password of the account login to system
    /// </summary>
    public string? Password { get; set; }

    /// <summary>s
    /// The role of the account login to system
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// The last date the user logged into the system
    /// </summary>
    public DateTime? LastDateLogin { get; set; }





}




