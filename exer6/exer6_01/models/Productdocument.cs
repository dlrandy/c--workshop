using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Cross-reference table mapping products to related product documents.
/// </summary>
public partial class Productdocument
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int Productid { get; set; }

    public DateTime Modifieddate { get; set; }

    /// <summary>
    /// Document identification number. Foreign key to Document.DocumentNode.
    /// </summary>
    public string Documentnode { get; set; } = null!;

    public virtual Document DocumentnodeNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
