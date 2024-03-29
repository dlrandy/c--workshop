﻿using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Transactions for previous years.
/// </summary>
public partial class Transactionhistoryarchive
{
    /// <summary>
    /// Primary key for TransactionHistoryArchive records.
    /// </summary>
    public int Transactionid { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Purchase order, sales order, or work order identification number.
    /// </summary>
    public int Referenceorderid { get; set; }

    /// <summary>
    /// Line number associated with the purchase order, sales order, or work order.
    /// </summary>
    public int Referenceorderlineid { get; set; }

    /// <summary>
    /// Date and time of the transaction.
    /// </summary>
    public DateTime Transactiondate { get; set; }

    /// <summary>
    /// W = Work Order, S = Sales Order, P = Purchase Order
    /// </summary>
    public char Transactiontype { get; set; }

    /// <summary>
    /// Product quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Product cost.
    /// </summary>
    public decimal Actualcost { get; set; }

    public DateTime Modifieddate { get; set; }
}
