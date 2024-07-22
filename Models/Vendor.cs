using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class Vendor
{
    /// <summary>
    /// The unique identifier for the vendor.
    /// </summary>
    public int VendorCode { get; set; }

    /// <summary>
    /// The name of the vendor.
    /// </summary>
    public string? VendorName { get; set; }

    /// <summary>
    /// The address of the vendor.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Vendor's phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Vendor's email address
    /// </summary>
    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
