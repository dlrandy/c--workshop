using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Product inventory and manufacturing locations.
/// </summary>
public partial class Location
{
    /// <summary>
    /// Primary key for Location records.
    /// </summary>
    public int Locationid { get; set; }

    /// <summary>
    /// Location description.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Standard hourly cost of the manufacturing location.
    /// </summary>
    public decimal Costrate { get; set; }

    /// <summary>
    /// Work capacity (in hours) of the manufacturing location.
    /// </summary>
    public decimal Availability { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Productinventory> Productinventories { get; set; } = new List<Productinventory>();

    public virtual ICollection<Workorderrouting> Workorderroutings { get; set; } = new List<Workorderrouting>();
}
