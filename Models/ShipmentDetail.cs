using System;
using System.Collections.Generic;

namespace SupplyTracker.Models;

public partial class ShipmentDetail
{
    /// <summary>
    /// The unique identifier for the shipment detail.
    /// </summary>
    public int ShipmentDetailId { get; set; }

    /// <summary>
    /// The unique identifier for the shipment.
    /// </summary>
    public int? ShipmentId { get; set; }

    /// <summary>
    /// The unique identifier for the product.
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    /// The quantity of the product ordered.
    /// </summary>
    public int? QuantityOrdered { get; set; }

    /// <summary>
    /// The quantity of the product received.
    /// </summary>
    public int? QuantityReceived { get; set; }

    /// <summary>
    /// The quantity of the product left.
    /// QuantityLeft = QuantityOrdered - QuantityReceived was computed in database
    /// </summary>
    public int? QuantityLeft { get; private set; }

    public virtual Product? Product { get; set; }

    public virtual Shipment? Shipment { get; set; }
}
