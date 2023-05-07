using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// High-level product categorization.
/// </summary>
public partial class Productcategory
{
    /// <summary>
    /// Primary key for ProductCategory records.
    /// </summary>
    public int Productcategoryid { get; set; }

    /// <summary>
    /// Category description.
    /// </summary>
    public string Name { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Productsubcategory> Productsubcategories { get; set; } = new List<Productsubcategory>();
}
