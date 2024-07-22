using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class Inventory
{
    /// <summary>
    /// The unique identifier for the inventory item.
    /// </summary>
    public int InventoryId { get; set; }

    /// <summary>
    /// The unique identifier for the product.
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// The quantity of the product in stock.
    /// </summary>
    public int? QuantityInStock { get; set; }

    /// <summary>
    /// The quantity of the product on re-order level.
    /// </summary>
    public int? ReorderLevel { get; set; }

    public virtual Product? Product { get; set; }
}
