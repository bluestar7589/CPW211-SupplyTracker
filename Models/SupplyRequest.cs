using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class SupplyRequest
{
    /// <summary>
    /// The unique identifier for the request.
    /// </summary>
    public int RequestId { get; set; }

    /// <summary>
    /// The name of the person making the request.
    /// </summary>
    public string? RequestorName { get; set; }

    /// <summary>
    /// The department code associated with the request.
    /// </summary>
    public int? DepartmentCode { get; set; }

    /// <summary>
    /// The date of the request.
    /// </summary>
    public DateOnly? DateOfRequest { get; set; }

    public virtual Department? DepartmentCodeNavigation { get; set; }
}
