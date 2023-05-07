using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Product subcategories. See ProductCategory table.
/// </summary>
public partial class Productsubcategory
{
    /// <summary>
    /// Primary key for ProductSubcategory records.
    /// </summary>
    public int Productsubcategoryid { get; set; }

    /// <summary>
    /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
    /// </summary>
    public int Productcategoryid { get; set; }

    /// <summary>
    /// Subcategory description.
    /// </summary>
    public string Name { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Productcategory Productcategory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
