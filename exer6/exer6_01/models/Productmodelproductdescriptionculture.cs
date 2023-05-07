using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Cross-reference table mapping product descriptions and the language the description is written in.
/// </summary>
public partial class Productmodelproductdescriptionculture
{
    /// <summary>
    /// Primary key. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    public int Productmodelid { get; set; }

    /// <summary>
    /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
    /// </summary>
    public int Productdescriptionid { get; set; }

    /// <summary>
    /// Culture identification number. Foreign key to Culture.CultureID.
    /// </summary>
    public string Cultureid { get; set; } = null!;

    public DateTime Modifieddate { get; set; }

    public virtual Culture Culture { get; set; } = null!;

    public virtual Productdescription Productdescription { get; set; } = null!;

    public virtual Productmodel Productmodel { get; set; } = null!;
}
