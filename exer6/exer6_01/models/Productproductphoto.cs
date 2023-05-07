using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Cross-reference table mapping products and product photos.
/// </summary>
public partial class Productproductphoto
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.
    /// </summary>
    public int Productphotoid { get; set; }

    /// <summary>
    /// 0 = Photo is not the principal image. 1 = Photo is the principal image.
    /// </summary>
    public bool Primary { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Productphoto Productphoto { get; set; } = null!;
}
