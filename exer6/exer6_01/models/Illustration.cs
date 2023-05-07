using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Bicycle assembly diagrams.
/// </summary>
public partial class Illustration
{
    /// <summary>
    /// Primary key for Illustration records.
    /// </summary>
    public int Illustrationid { get; set; }

    /// <summary>
    /// Illustrations used in manufacturing instructions. Stored as XML.
    /// </summary>
    public string? Diagram { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Productmodelillustration> Productmodelillustrations { get; set; } = new List<Productmodelillustration>();
}
