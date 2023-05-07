using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Manufacturing failure reasons lookup table.
/// </summary>
public partial class Scrapreason
{
    /// <summary>
    /// Primary key for ScrapReason records.
    /// </summary>
    public int Scrapreasonid { get; set; }

    /// <summary>
    /// Failure description.
    /// </summary>
    public string Name { get; set; } = null!;

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Workorder> Workorders { get; set; } = new List<Workorder>();
}
