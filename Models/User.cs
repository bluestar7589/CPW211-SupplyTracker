using System;
using System.Collections.Generic;

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
}
