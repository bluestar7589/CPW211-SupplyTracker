using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class Department
{
    /// <summary>
    /// The unique identifier for the department.
    /// </summary>
    public int DepartmentCode { get; set; }

    /// <summary>
    /// Name for each department
    /// </summary>
    public string? DepartmentName { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<SupplyRequest> SupplyRequests { get; set; } = new List<SupplyRequest>();
}
