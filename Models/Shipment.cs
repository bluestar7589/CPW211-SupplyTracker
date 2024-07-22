using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class Shipment
{
    /// <summary>
    /// The unique identifier for the shipment.
    /// </summary>
    public int ShipmentId { get; set; }

    /// <summary>
    /// The unique identifier for the vendor.
    /// </summary>
    public int? VendorCode { get; set; }

    /// <summary>
    /// The date the shipment was received.
    /// </summary>
    public DateOnly? ShipmentDate { get; set; }

    /// <summary>
    /// The status of the shipment.
    /// </summary>
    public string? Status { get; set; }

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();

    public virtual Vendor? VendorCodeNavigation { get; set; }
}
