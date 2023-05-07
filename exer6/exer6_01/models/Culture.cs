using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Lookup table containing the languages in which some AdventureWorks data is stored.
/// </summary>
public partial class Culture
{
    /// <summary>
    /// Primary key for Culture records.
    /// </summary>
    public string Cultureid { get; set; } = null!;

    /// <summary>
    /// Culture description.
    /// </summary>
    public string Name { get; set; } = null!;

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; } = new List<Productmodelproductdescriptionculture>();
}
