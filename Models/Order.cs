using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class Order
{
    /// <summary>
    /// The unique identifier for the order.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// The unique identifier for the customer who placed the order.
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// The unique identifier for the vendor who fulfilled the order.
    /// </summary>
    public int? VendorId { get; set; }

    /// <summary>
    /// The date the order was placed.
    /// </summary>
    public DateOnly? DateOfOrder { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Vendor? Vendor { get; set; }
}
