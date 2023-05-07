using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Product descriptions in several languages.
/// </summary>
public partial class Productdescription
{
    /// <summary>
    /// Primary key for ProductDescription records.
    /// </summary>
    public int Productdescriptionid { get; set; }

    /// <summary>
    /// Description of the product.
    /// </summary>
    public string Description { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; } = new List<Productmodelproductdescriptionculture>();
}
