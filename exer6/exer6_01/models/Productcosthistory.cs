using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Changes in the cost of a product over time.
/// </summary>
public partial class Productcosthistory
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Product cost start date.
    /// </summary>
    public DateTime Startdate { get; set; }

    /// <summary>
    /// Product cost end date.
    /// </summary>
    public DateTime? Enddate { get; set; }

    /// <summary>
    /// Standard cost of the product.
    /// </summary>
    public decimal Standardcost { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
