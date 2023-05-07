using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.
/// </summary>
public partial class Billofmaterial
{
    /// <summary>
    /// Primary key for BillOfMaterials records.
    /// </summary>
    public int Billofmaterialsid { get; set; }

    /// <summary>
    /// Parent product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int? Productassemblyid { get; set; }

    /// <summary>
    /// Component identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int Componentid { get; set; }

    /// <summary>
    /// Date the component started being used in the assembly item.
    /// </summary>
    public DateTime Startdate { get; set; }

    /// <summary>
    /// Date the component stopped being used in the assembly item.
    /// </summary>
    public DateTime? Enddate { get; set; }

    /// <summary>
    /// Standard code identifying the unit of measure for the quantity.
    /// </summary>
    public string Unitmeasurecode { get; set; } = null!;

    /// <summary>
    /// Indicates the depth the component is from its parent (AssemblyID).
    /// </summary>
    public short Bomlevel { get; set; }

    /// <summary>
    /// Quantity of the component needed to create the assembly.
    /// </summary>
    public decimal Perassemblyqty { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Product Component { get; set; } = null!;

    public virtual Product? Productassembly { get; set; }

    public virtual Unitmeasure UnitmeasurecodeNavigation { get; set; } = null!;
}
