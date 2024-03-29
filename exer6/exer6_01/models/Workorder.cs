﻿using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Manufacturing work orders.
/// </summary>
public partial class Workorder
{
    /// <summary>
    /// Primary key for WorkOrder records.
    /// </summary>
    public int Workorderid { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Product quantity to build.
    /// </summary>
    public int Orderqty { get; set; }

    /// <summary>
    /// Quantity that failed inspection.
    /// </summary>
    public short Scrappedqty { get; set; }

    /// <summary>
    /// Work order start date.
    /// </summary>
    public DateTime Startdate { get; set; }

    /// <summary>
    /// Work order end date.
    /// </summary>
    public DateTime? Enddate { get; set; }

    /// <summary>
    /// Work order due date.
    /// </summary>
    public DateTime Duedate { get; set; }

    /// <summary>
    /// Reason for inspection failure.
    /// </summary>
    public int? Scrapreasonid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Scrapreason? Scrapreason { get; set; }

    public virtual ICollection<Workorderrouting> Workorderroutings { get; set; } = new List<Workorderrouting>();
}
