using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Cross-reference table mapping product models and illustrations.
/// </summary>
public partial class Productmodelillustration
{
    /// <summary>
    /// Primary key. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    public int Productmodelid { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Illustration.IllustrationID.
    /// </summary>
    public int Illustrationid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Illustration Illustration { get; set; } = null!;

    public virtual Productmodel Productmodel { get; set; } = null!;
}
