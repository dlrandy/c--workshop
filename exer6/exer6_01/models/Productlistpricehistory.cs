﻿using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Changes in the list price of a product over time.
/// </summary>
public partial class Productlistpricehistory
{
    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// List price start date.
    /// </summary>
    public DateTime Startdate { get; set; }

    /// <summary>
    /// List price end date
    /// </summary>
    public DateTime? Enddate { get; set; }

    /// <summary>
    /// Product list price.
    /// </summary>
    public decimal Listprice { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
