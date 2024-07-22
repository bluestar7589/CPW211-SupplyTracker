using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class OrderDetail
{
    /// <summary>
    /// The unique identifier for the order detail.
    /// </summary>
    public int OrderDetailId { get; set; }

    /// <summary>
    /// The unique identifier for the order.
    /// </summary>
    public int? OrderId { get; set; }

    /// <summary>
    /// The unique identifier for the product.
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// The quantity of the product in the order.
    /// </summary>
    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
