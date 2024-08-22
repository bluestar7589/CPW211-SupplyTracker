using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class Customer
{
    /// <summary>
    /// The unique identifier for the customer.
    /// </summary>
    public int CustomerID { get; set; }

    /// <summary>
    /// The first name of the customer.
    /// </summary>
    public string? FirstName { get; set; }


    /// <summary>
    /// The last name of the customer.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// The code for each department
    /// </summary>
    public int? DepartmentCode { get; set; }

    /// <summary>
    /// Customer's phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Customer's position
    /// </summary>
    public string? Position { get; set; }

    public virtual Department? DepartmentCodeNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
