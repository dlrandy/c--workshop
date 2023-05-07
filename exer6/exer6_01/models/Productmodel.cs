using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Product model classification.
/// </summary>
public partial class Productmodel
{
    /// <summary>
    /// Primary key for ProductModel records.
    /// </summary>
    public int Productmodelid { get; set; }

    /// <summary>
    /// Product model description.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Detailed product catalog information in xml format.
    /// </summary>
    public string? Catalogdescription { get; set; }

    /// <summary>
    /// Manufacturing instructions in xml format.
    /// </summary>
    public string? Instructions { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Productmodelillustration> Productmodelillustrations { get; set; } = new List<Productmodelillustration>();

    public virtual ICollection<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; } = new List<Productmodelproductdescriptionculture>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
