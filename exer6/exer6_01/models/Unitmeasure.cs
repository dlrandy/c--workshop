using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Unit of measure lookup table.
/// </summary>
public partial class Unitmeasure
{
    /// <summary>
    /// Primary key.
    /// </summary>
    public string Unitmeasurecode { get; set; } = null!;

    /// <summary>
    /// Unit of measure description.
    /// </summary>
    public string Name { get; set; } = null!;

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Billofmaterial> Billofmaterials { get; set; } = new List<Billofmaterial>();

    public virtual ICollection<Product> ProductSizeunitmeasurecodeNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductWeightunitmeasurecodeNavigations { get; set; } = new List<Product>();
}
