using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Product inventory information.
/// </summary>
public partial class Productinventory
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Inventory location identification number. Foreign key to Location.LocationID.
    /// </summary>
    public int Locationid { get; set; }

    /// <summary>
    /// Storage compartment within an inventory location.
    /// </summary>
    public string Shelf { get; set; } = null!;

    /// <summary>
    /// Storage container on a shelf in an inventory location.
    /// </summary>
    public short Bin { get; set; }

    /// <summary>
    /// Quantity of products in the inventory location.
    /// </summary>
    public short Quantity { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
