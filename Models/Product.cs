using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class Product
{
    /// <summary>
    /// The unique identifier for the product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// The product name.
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// The lotnumber for the product.
    /// </summary>
    public string? LotNumber { get; set; }

    /// <summary>
    /// The price of the product.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// The unit of the supply for product
    /// </summary>
    public string? UnitOfSupply { get; set; }

    /// <summary>
    /// The date of production for the product.
    /// </summary>
    public DateOnly? DateOfProduct { get; set; }

    /// <summary>
    /// The date of expiration for the product.
    /// </summary>
    public DateOnly? DateOfExpire { get; set; }

    /// <summary>
    /// The product category code.
    /// </summary>
    public int? ProductCategoryCode { get; set; }

    /// <summary>
    /// The vendor code.
    /// </summary>
    public int? VendorCode { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductCategory? ProductCategoryCodeNavigation { get; set; }

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();

    public virtual Vendor? VendorCodeNavigation { get; set; }
}
