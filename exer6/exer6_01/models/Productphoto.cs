using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Product images.
/// </summary>
public partial class Productphoto
{
    /// <summary>
    /// Primary key for ProductPhoto records.
    /// </summary>
    public int Productphotoid { get; set; }

    /// <summary>
    /// Small image of the product.
    /// </summary>
    public byte[]? Thumbnailphoto { get; set; }

    /// <summary>
    /// Small image file name.
    /// </summary>
    public string? Thumbnailphotofilename { get; set; }

    /// <summary>
    /// Large image of the product.
    /// </summary>
    public byte[]? Largephoto { get; set; }

    /// <summary>
    /// Large image file name.
    /// </summary>
    public string? Largephotofilename { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Productproductphoto> Productproductphotos { get; set; } = new List<Productproductphoto>();
}
