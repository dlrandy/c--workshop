﻿using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Work order details.
/// </summary>
public partial class Workorderrouting
{
    /// <summary>
    /// Primary key. Foreign key to WorkOrder.WorkOrderID.
    /// </summary>
    public int Workorderid { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Product.ProductID.
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Primary key. Indicates the manufacturing process sequence.
    /// </summary>
    public short Operationsequence { get; set; }

    /// <summary>
    /// Manufacturing location where the part is processed. Foreign key to Location.LocationID.
    /// </summary>
    public int Locationid { get; set; }

    /// <summary>
    /// Planned manufacturing start date.
    /// </summary>
    public DateTime Scheduledstartdate { get; set; }

    /// <summary>
    /// Planned manufacturing end date.
    /// </summary>
    public DateTime Scheduledenddate { get; set; }

    /// <summary>
    /// Actual start date.
    /// </summary>
    public DateTime? Actualstartdate { get; set; }

    /// <summary>
    /// Actual end date.
    /// </summary>
    public DateTime? Actualenddate { get; set; }

    /// <summary>
    /// Number of manufacturing hours used.
    /// </summary>
    public decimal? Actualresourcehrs { get; set; }

    /// <summary>
    /// Estimated manufacturing cost.
    /// </summary>
    public decimal Plannedcost { get; set; }

    /// <summary>
    /// Actual manufacturing cost.
    /// </summary>
    public decimal? Actualcost { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual Workorder Workorder { get; set; } = null!;
}
