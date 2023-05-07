using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Products sold or used in the manfacturing of sold products.
/// </summary>
public partial class Product
{
    /// <summary>
    /// Primary key for Product records.
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Unique product identification number.
    /// </summary>
    public string Productnumber { get; set; } = null!;

    /// <summary>
    /// 0 = Product is purchased, 1 = Product is manufactured in-house.
    /// </summary>
    public bool? Makeflag { get; set; }

    /// <summary>
    /// 0 = Product is not a salable item. 1 = Product is salable.
    /// </summary>
    public bool? Finishedgoodsflag { get; set; }

    /// <summary>
    /// Product color.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Minimum inventory quantity.
    /// </summary>
    public short Safetystocklevel { get; set; }

    /// <summary>
    /// Inventory level that triggers a purchase order or work order.
    /// </summary>
    public short Reorderpoint { get; set; }

    /// <summary>
    /// Standard cost of the product.
    /// </summary>
    public decimal Standardcost { get; set; }

    /// <summary>
    /// Selling price.
    /// </summary>
    public decimal Listprice { get; set; }

    /// <summary>
    /// Product size.
    /// </summary>
    public string? Size { get; set; }

    /// <summary>
    /// Unit of measure for Size column.
    /// </summary>
    public string? Sizeunitmeasurecode { get; set; }

    /// <summary>
    /// Unit of measure for Weight column.
    /// </summary>
    public string? Weightunitmeasurecode { get; set; }

    /// <summary>
    /// Product weight.
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// Number of days required to manufacture the product.
    /// </summary>
    public int Daystomanufacture { get; set; }

    /// <summary>
    /// R = Road, M = Mountain, T = Touring, S = Standard
    /// </summary>
    public string? Productline { get; set; }

    /// <summary>
    /// H = High, M = Medium, L = Low
    /// </summary>
    public string? Class { get; set; }

    /// <summary>
    /// W = Womens, M = Mens, U = Universal
    /// </summary>
    public string? Style { get; set; }

    /// <summary>
    /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID.
    /// </summary>
    public int? Productsubcategoryid { get; set; }

    /// <summary>
    /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    public int? Productmodelid { get; set; }

    /// <summary>
    /// Date the product was available for sale.
    /// </summary>
    public DateTime Sellstartdate { get; set; }

    /// <summary>
    /// Date the product was no longer available for sale.
    /// </summary>
    public DateTime? Sellenddate { get; set; }

    /// <summary>
    /// Date the product was discontinued.
    /// </summary>
    public DateTime? Discontinueddate { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual ICollection<Billofmaterial> BillofmaterialComponents { get; set; } = new List<Billofmaterial>();

    public virtual ICollection<Billofmaterial> BillofmaterialProductassemblies { get; set; } = new List<Billofmaterial>();

    public virtual ICollection<Productcosthistory> Productcosthistories { get; set; } = new List<Productcosthistory>();

    public virtual ICollection<Productdocument> Productdocuments { get; set; } = new List<Productdocument>();

    public virtual ICollection<Productinventory> Productinventories { get; set; } = new List<Productinventory>();

    public virtual ICollection<Productlistpricehistory> Productlistpricehistories { get; set; } = new List<Productlistpricehistory>();

    public virtual Productmodel? Productmodel { get; set; }

    public virtual ICollection<Productproductphoto> Productproductphotos { get; set; } = new List<Productproductphoto>();

    public virtual ICollection<Productreview> Productreviews { get; set; } = new List<Productreview>();

    public virtual Productsubcategory? Productsubcategory { get; set; }

    public virtual Unitmeasure? SizeunitmeasurecodeNavigation { get; set; }

    public virtual ICollection<Transactionhistory> Transactionhistories { get; set; } = new List<Transactionhistory>();

    public virtual Unitmeasure? WeightunitmeasurecodeNavigation { get; set; }

    public virtual ICollection<Workorder> Workorders { get; set; } = new List<Workorder>();
}
