using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Record of each purchase order, sales order, or work order transaction year to date.
/// </summary>
public partial class Transactionhistory
{
    /// <summary>
    /// Primary key for TransactionHistory records.
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
    /// W = WorkOrder, S = SalesOrder, P = PurchaseOrder
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

    public virtual Product Product { get; set; } = null!;
}
