using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace exer6_01.models;

public partial class AdventureworksContext : DbContext
{
    public AdventureworksContext()
    {
    }

    public AdventureworksContext(DbContextOptions<AdventureworksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Billofmaterial> Billofmaterials { get; set; }

    public virtual DbSet<Culture> Cultures { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Illustration> Illustrations { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productcategory> Productcategories { get; set; }

    public virtual DbSet<Productcosthistory> Productcosthistories { get; set; }

    public virtual DbSet<Productdescription> Productdescriptions { get; set; }

    public virtual DbSet<Productdocument> Productdocuments { get; set; }

    public virtual DbSet<Productinventory> Productinventories { get; set; }

    public virtual DbSet<Productlistpricehistory> Productlistpricehistories { get; set; }

    public virtual DbSet<Productmodel> Productmodels { get; set; }

    public virtual DbSet<Productmodelillustration> Productmodelillustrations { get; set; }

    public virtual DbSet<Productmodelproductdescriptionculture> Productmodelproductdescriptioncultures { get; set; }

    public virtual DbSet<Productphoto> Productphotos { get; set; }

    public virtual DbSet<Productproductphoto> Productproductphotos { get; set; }

    public virtual DbSet<Productreview> Productreviews { get; set; }

    public virtual DbSet<Productsubcategory> Productsubcategories { get; set; }

    public virtual DbSet<Scrapreason> Scrapreasons { get; set; }

    public virtual DbSet<Transactionhistory> Transactionhistories { get; set; }

    public virtual DbSet<Transactionhistoryarchive> Transactionhistoryarchives { get; set; }

    public virtual DbSet<Unitmeasure> Unitmeasures { get; set; }

    public virtual DbSet<Vproductanddescription> Vproductanddescriptions { get; set; }

    public virtual DbSet<Vproductmodelcatalogdescription> Vproductmodelcatalogdescriptions { get; set; }

    public virtual DbSet<Vproductmodelinstruction> Vproductmodelinstructions { get; set; }

    public virtual DbSet<Workorder> Workorders { get; set; }

    public virtual DbSet<Workorderrouting> Workorderroutings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=Adventureworks");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Billofmaterial>(entity =>
        {
            entity.HasKey(e => e.Billofmaterialsid).HasName("PK_BillOfMaterials_BillOfMaterialsID");

            entity.ToTable("billofmaterials", "production", tb => tb.HasComment("Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."));

            entity.Property(e => e.Billofmaterialsid)
                .HasComment("Primary key for BillOfMaterials records.")
                .HasColumnName("billofmaterialsid");
            entity.Property(e => e.Bomlevel)
                .HasComment("Indicates the depth the component is from its parent (AssemblyID).")
                .HasColumnName("bomlevel");
            entity.Property(e => e.Componentid)
                .HasComment("Component identification number. Foreign key to Product.ProductID.")
                .HasColumnName("componentid");
            entity.Property(e => e.Enddate)
                .HasComment("Date the component stopped being used in the assembly item.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Perassemblyqty)
                .HasPrecision(8, 2)
                .HasDefaultValueSql("1.00")
                .HasComment("Quantity of the component needed to create the assembly.")
                .HasColumnName("perassemblyqty");
            entity.Property(e => e.Productassemblyid)
                .HasComment("Parent product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productassemblyid");
            entity.Property(e => e.Startdate)
                .HasDefaultValueSql("now()")
                .HasComment("Date the component started being used in the assembly item.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Unitmeasurecode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Standard code identifying the unit of measure for the quantity.")
                .HasColumnName("unitmeasurecode");

            entity.HasOne(d => d.Component).WithMany(p => p.BillofmaterialComponents)
                .HasForeignKey(d => d.Componentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillOfMaterials_Product_ComponentID");

            entity.HasOne(d => d.Productassembly).WithMany(p => p.BillofmaterialProductassemblies)
                .HasForeignKey(d => d.Productassemblyid)
                .HasConstraintName("FK_BillOfMaterials_Product_ProductAssemblyID");

            entity.HasOne(d => d.UnitmeasurecodeNavigation).WithMany(p => p.Billofmaterials)
                .HasForeignKey(d => d.Unitmeasurecode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillOfMaterials_UnitMeasure_UnitMeasureCode");
        });

        modelBuilder.Entity<Culture>(entity =>
        {
            entity.HasKey(e => e.Cultureid).HasName("PK_Culture_CultureID");

            entity.ToTable("culture", "production", tb => tb.HasComment("Lookup table containing the languages in which some AdventureWorks data is stored."));

            entity.Property(e => e.Cultureid)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Primary key for Culture records.")
                .HasColumnName("cultureid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Culture description.")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Documentnode).HasName("PK_Document_DocumentNode");

            entity.ToTable("document", "production", tb => tb.HasComment("Product maintenance documents."));

            entity.HasIndex(e => e.Rowguid, "document_rowguid_key").IsUnique();

            entity.Property(e => e.Documentnode)
                .HasDefaultValueSql("'/'::character varying")
                .HasComment("Primary key for Document records.")
                .HasColumnType("character varying")
                .HasColumnName("documentnode");
            entity.Property(e => e.Changenumber)
                .HasComment("Engineering change approval number.")
                .HasColumnName("changenumber");
            entity.Property(e => e.Document1)
                .HasComment("Complete document.")
                .HasColumnName("document");
            entity.Property(e => e.Documentsummary)
                .HasComment("Document abstract.")
                .HasColumnName("documentsummary");
            entity.Property(e => e.Fileextension)
                .HasMaxLength(8)
                .HasComment("File extension indicating the document type. For example, .doc or .txt.")
                .HasColumnName("fileextension");
            entity.Property(e => e.Filename)
                .HasMaxLength(400)
                .HasComment("File name of the document")
                .HasColumnName("filename");
            entity.Property(e => e.Folderflag)
                .HasComment("0 = This is a folder, 1 = This is a document.")
                .HasColumnName("folderflag");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Owner)
                .HasComment("Employee who controls the document.  Foreign key to Employee.BusinessEntityID")
                .HasColumnName("owner");
            entity.Property(e => e.Revision)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("Revision number of the document.")
                .HasColumnName("revision");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("uuid_generate_v1()")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Required for FileStream.")
                .HasColumnName("rowguid");
            entity.Property(e => e.Status)
                .HasComment("1 = Pending approval, 2 = Approved, 3 = Obsolete")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("Title of the document.")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Illustration>(entity =>
        {
            entity.HasKey(e => e.Illustrationid).HasName("PK_Illustration_IllustrationID");

            entity.ToTable("illustration", "production", tb => tb.HasComment("Bicycle assembly diagrams."));

            entity.Property(e => e.Illustrationid)
                .HasComment("Primary key for Illustration records.")
                .HasColumnName("illustrationid");
            entity.Property(e => e.Diagram)
                .HasComment("Illustrations used in manufacturing instructions. Stored as XML.")
                .HasColumnType("xml")
                .HasColumnName("diagram");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Locationid).HasName("PK_Location_LocationID");

            entity.ToTable("location", "production", tb => tb.HasComment("Product inventory and manufacturing locations."));

            entity.Property(e => e.Locationid)
                .HasComment("Primary key for Location records.")
                .HasColumnName("locationid");
            entity.Property(e => e.Availability)
                .HasPrecision(8, 2)
                .HasDefaultValueSql("0.00")
                .HasComment("Work capacity (in hours) of the manufacturing location.")
                .HasColumnName("availability");
            entity.Property(e => e.Costrate)
                .HasDefaultValueSql("0.00")
                .HasComment("Standard hourly cost of the manufacturing location.")
                .HasColumnName("costrate");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Location description.")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("PK_Product_ProductID");

            entity.ToTable("product", "production", tb => tb.HasComment("Products sold or used in the manfacturing of sold products."));

            entity.Property(e => e.Productid)
                .HasComment("Primary key for Product records.")
                .HasColumnName("productid");
            entity.Property(e => e.Class)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("H = High, M = Medium, L = Low")
                .HasColumnName("class");
            entity.Property(e => e.Color)
                .HasMaxLength(15)
                .HasComment("Product color.")
                .HasColumnName("color");
            entity.Property(e => e.Daystomanufacture)
                .HasComment("Number of days required to manufacture the product.")
                .HasColumnName("daystomanufacture");
            entity.Property(e => e.Discontinueddate)
                .HasComment("Date the product was discontinued.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("discontinueddate");
            entity.Property(e => e.Finishedgoodsflag)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasComment("0 = Product is not a salable item. 1 = Product is salable.")
                .HasColumnName("finishedgoodsflag");
            entity.Property(e => e.Listprice)
                .HasComment("Selling price.")
                .HasColumnName("listprice");
            entity.Property(e => e.Makeflag)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.")
                .HasColumnName("makeflag");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Name of the product.")
                .HasColumnName("name");
            entity.Property(e => e.Productline)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("R = Road, M = Mountain, T = Touring, S = Standard")
                .HasColumnName("productline");
            entity.Property(e => e.Productmodelid)
                .HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.")
                .HasColumnName("productmodelid");
            entity.Property(e => e.Productnumber)
                .HasMaxLength(25)
                .HasComment("Unique product identification number.")
                .HasColumnName("productnumber");
            entity.Property(e => e.Productsubcategoryid)
                .HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID.")
                .HasColumnName("productsubcategoryid");
            entity.Property(e => e.Reorderpoint)
                .HasComment("Inventory level that triggers a purchase order or work order.")
                .HasColumnName("reorderpoint");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("uuid_generate_v1()")
                .HasColumnName("rowguid");
            entity.Property(e => e.Safetystocklevel)
                .HasComment("Minimum inventory quantity.")
                .HasColumnName("safetystocklevel");
            entity.Property(e => e.Sellenddate)
                .HasComment("Date the product was no longer available for sale.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sellenddate");
            entity.Property(e => e.Sellstartdate)
                .HasComment("Date the product was available for sale.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sellstartdate");
            entity.Property(e => e.Size)
                .HasMaxLength(5)
                .HasComment("Product size.")
                .HasColumnName("size");
            entity.Property(e => e.Sizeunitmeasurecode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Unit of measure for Size column.")
                .HasColumnName("sizeunitmeasurecode");
            entity.Property(e => e.Standardcost)
                .HasComment("Standard cost of the product.")
                .HasColumnName("standardcost");
            entity.Property(e => e.Style)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("W = Womens, M = Mens, U = Universal")
                .HasColumnName("style");
            entity.Property(e => e.Weight)
                .HasPrecision(8, 2)
                .HasComment("Product weight.")
                .HasColumnName("weight");
            entity.Property(e => e.Weightunitmeasurecode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Unit of measure for Weight column.")
                .HasColumnName("weightunitmeasurecode");

            entity.HasOne(d => d.Productmodel).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productmodelid)
                .HasConstraintName("FK_Product_ProductModel_ProductModelID");

            entity.HasOne(d => d.Productsubcategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.Productsubcategoryid)
                .HasConstraintName("FK_Product_ProductSubcategory_ProductSubcategoryID");

            entity.HasOne(d => d.SizeunitmeasurecodeNavigation).WithMany(p => p.ProductSizeunitmeasurecodeNavigations)
                .HasForeignKey(d => d.Sizeunitmeasurecode)
                .HasConstraintName("FK_Product_UnitMeasure_SizeUnitMeasureCode");

            entity.HasOne(d => d.WeightunitmeasurecodeNavigation).WithMany(p => p.ProductWeightunitmeasurecodeNavigations)
                .HasForeignKey(d => d.Weightunitmeasurecode)
                .HasConstraintName("FK_Product_UnitMeasure_WeightUnitMeasureCode");
        });

        modelBuilder.Entity<Productcategory>(entity =>
        {
            entity.HasKey(e => e.Productcategoryid).HasName("PK_ProductCategory_ProductCategoryID");

            entity.ToTable("productcategory", "production", tb => tb.HasComment("High-level product categorization."));

            entity.Property(e => e.Productcategoryid)
                .HasComment("Primary key for ProductCategory records.")
                .HasColumnName("productcategoryid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Category description.")
                .HasColumnName("name");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("uuid_generate_v1()")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<Productcosthistory>(entity =>
        {
            entity.HasKey(e => new { e.Productid, e.Startdate }).HasName("PK_ProductCostHistory_ProductID_StartDate");

            entity.ToTable("productcosthistory", "production", tb => tb.HasComment("Changes in the cost of a product over time."));

            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID")
                .HasColumnName("productid");
            entity.Property(e => e.Startdate)
                .HasComment("Product cost start date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Enddate)
                .HasComment("Product cost end date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Standardcost)
                .HasComment("Standard cost of the product.")
                .HasColumnName("standardcost");

            entity.HasOne(d => d.Product).WithMany(p => p.Productcosthistories)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCostHistory_Product_ProductID");
        });

        modelBuilder.Entity<Productdescription>(entity =>
        {
            entity.HasKey(e => e.Productdescriptionid).HasName("PK_ProductDescription_ProductDescriptionID");

            entity.ToTable("productdescription", "production", tb => tb.HasComment("Product descriptions in several languages."));

            entity.Property(e => e.Productdescriptionid)
                .HasComment("Primary key for ProductDescription records.")
                .HasColumnName("productdescriptionid");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasComment("Description of the product.")
                .HasColumnName("description");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("uuid_generate_v1()")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<Productdocument>(entity =>
        {
            entity.HasKey(e => new { e.Productid, e.Documentnode }).HasName("PK_ProductDocument_ProductID_DocumentNode");

            entity.ToTable("productdocument", "production", tb => tb.HasComment("Cross-reference table mapping products to related product documents."));

            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Documentnode)
                .HasDefaultValueSql("'/'::character varying")
                .HasComment("Document identification number. Foreign key to Document.DocumentNode.")
                .HasColumnType("character varying")
                .HasColumnName("documentnode");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");

            entity.HasOne(d => d.DocumentnodeNavigation).WithMany(p => p.Productdocuments)
                .HasForeignKey(d => d.Documentnode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductDocument_Document_DocumentNode");

            entity.HasOne(d => d.Product).WithMany(p => p.Productdocuments)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductDocument_Product_ProductID");
        });

        modelBuilder.Entity<Productinventory>(entity =>
        {
            entity.HasKey(e => new { e.Productid, e.Locationid }).HasName("PK_ProductInventory_ProductID_LocationID");

            entity.ToTable("productinventory", "production", tb => tb.HasComment("Product inventory information."));

            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Locationid)
                .HasComment("Inventory location identification number. Foreign key to Location.LocationID.")
                .HasColumnName("locationid");
            entity.Property(e => e.Bin)
                .HasComment("Storage container on a shelf in an inventory location.")
                .HasColumnName("bin");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Quantity)
                .HasComment("Quantity of products in the inventory location.")
                .HasColumnName("quantity");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("uuid_generate_v1()")
                .HasColumnName("rowguid");
            entity.Property(e => e.Shelf)
                .HasMaxLength(10)
                .HasComment("Storage compartment within an inventory location.")
                .HasColumnName("shelf");

            entity.HasOne(d => d.Location).WithMany(p => p.Productinventories)
                .HasForeignKey(d => d.Locationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInventory_Location_LocationID");

            entity.HasOne(d => d.Product).WithMany(p => p.Productinventories)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInventory_Product_ProductID");
        });

        modelBuilder.Entity<Productlistpricehistory>(entity =>
        {
            entity.HasKey(e => new { e.Productid, e.Startdate }).HasName("PK_ProductListPriceHistory_ProductID_StartDate");

            entity.ToTable("productlistpricehistory", "production", tb => tb.HasComment("Changes in the list price of a product over time."));

            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID")
                .HasColumnName("productid");
            entity.Property(e => e.Startdate)
                .HasComment("List price start date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Enddate)
                .HasComment("List price end date")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Listprice)
                .HasComment("Product list price.")
                .HasColumnName("listprice");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");

            entity.HasOne(d => d.Product).WithMany(p => p.Productlistpricehistories)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductListPriceHistory_Product_ProductID");
        });

        modelBuilder.Entity<Productmodel>(entity =>
        {
            entity.HasKey(e => e.Productmodelid).HasName("PK_ProductModel_ProductModelID");

            entity.ToTable("productmodel", "production", tb => tb.HasComment("Product model classification."));

            entity.Property(e => e.Productmodelid)
                .HasComment("Primary key for ProductModel records.")
                .HasColumnName("productmodelid");
            entity.Property(e => e.Catalogdescription)
                .HasComment("Detailed product catalog information in xml format.")
                .HasColumnType("xml")
                .HasColumnName("catalogdescription");
            entity.Property(e => e.Instructions)
                .HasComment("Manufacturing instructions in xml format.")
                .HasColumnType("xml")
                .HasColumnName("instructions");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Product model description.")
                .HasColumnName("name");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("uuid_generate_v1()")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<Productmodelillustration>(entity =>
        {
            entity.HasKey(e => new { e.Productmodelid, e.Illustrationid }).HasName("PK_ProductModelIllustration_ProductModelID_IllustrationID");

            entity.ToTable("productmodelillustration", "production", tb => tb.HasComment("Cross-reference table mapping product models and illustrations."));

            entity.Property(e => e.Productmodelid)
                .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.")
                .HasColumnName("productmodelid");
            entity.Property(e => e.Illustrationid)
                .HasComment("Primary key. Foreign key to Illustration.IllustrationID.")
                .HasColumnName("illustrationid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");

            entity.HasOne(d => d.Illustration).WithMany(p => p.Productmodelillustrations)
                .HasForeignKey(d => d.Illustrationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductModelIllustration_Illustration_IllustrationID");

            entity.HasOne(d => d.Productmodel).WithMany(p => p.Productmodelillustrations)
                .HasForeignKey(d => d.Productmodelid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductModelIllustration_ProductModel_ProductModelID");
        });

        modelBuilder.Entity<Productmodelproductdescriptionculture>(entity =>
        {
            entity.HasKey(e => new { e.Productmodelid, e.Productdescriptionid, e.Cultureid }).HasName("PK_ProductModelProductDescriptionCulture_ProductModelID_Product");

            entity.ToTable("productmodelproductdescriptionculture", "production", tb => tb.HasComment("Cross-reference table mapping product descriptions and the language the description is written in."));

            entity.Property(e => e.Productmodelid)
                .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.")
                .HasColumnName("productmodelid");
            entity.Property(e => e.Productdescriptionid)
                .HasComment("Primary key. Foreign key to ProductDescription.ProductDescriptionID.")
                .HasColumnName("productdescriptionid");
            entity.Property(e => e.Cultureid)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Culture identification number. Foreign key to Culture.CultureID.")
                .HasColumnName("cultureid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");

            entity.HasOne(d => d.Culture).WithMany(p => p.Productmodelproductdescriptioncultures)
                .HasForeignKey(d => d.Cultureid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductModelProductDescriptionCulture_Culture_CultureID");

            entity.HasOne(d => d.Productdescription).WithMany(p => p.Productmodelproductdescriptioncultures)
                .HasForeignKey(d => d.Productdescriptionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductDescription_Pro");

            entity.HasOne(d => d.Productmodel).WithMany(p => p.Productmodelproductdescriptioncultures)
                .HasForeignKey(d => d.Productmodelid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductModel_ProductMo");
        });

        modelBuilder.Entity<Productphoto>(entity =>
        {
            entity.HasKey(e => e.Productphotoid).HasName("PK_ProductPhoto_ProductPhotoID");

            entity.ToTable("productphoto", "production", tb => tb.HasComment("Product images."));

            entity.Property(e => e.Productphotoid)
                .HasComment("Primary key for ProductPhoto records.")
                .HasColumnName("productphotoid");
            entity.Property(e => e.Largephoto)
                .HasComment("Large image of the product.")
                .HasColumnName("largephoto");
            entity.Property(e => e.Largephotofilename)
                .HasMaxLength(50)
                .HasComment("Large image file name.")
                .HasColumnName("largephotofilename");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Thumbnailphoto)
                .HasComment("Small image of the product.")
                .HasColumnName("thumbnailphoto");
            entity.Property(e => e.Thumbnailphotofilename)
                .HasMaxLength(50)
                .HasComment("Small image file name.")
                .HasColumnName("thumbnailphotofilename");
        });

        modelBuilder.Entity<Productproductphoto>(entity =>
        {
            entity.HasKey(e => new { e.Productid, e.Productphotoid }).HasName("PK_ProductProductPhoto_ProductID_ProductPhotoID");

            entity.ToTable("productproductphoto", "production", tb => tb.HasComment("Cross-reference table mapping products and product photos."));

            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Productphotoid)
                .HasComment("Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.")
                .HasColumnName("productphotoid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Primary)
                .HasComment("0 = Photo is not the principal image. 1 = Photo is the principal image.")
                .HasColumnName("primary");

            entity.HasOne(d => d.Product).WithMany(p => p.Productproductphotos)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductProductPhoto_Product_ProductID");

            entity.HasOne(d => d.Productphoto).WithMany(p => p.Productproductphotos)
                .HasForeignKey(d => d.Productphotoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductProductPhoto_ProductPhoto_ProductPhotoID");
        });

        modelBuilder.Entity<Productreview>(entity =>
        {
            entity.HasKey(e => e.Productreviewid).HasName("PK_ProductReview_ProductReviewID");

            entity.ToTable("productreview", "production", tb => tb.HasComment("Customer reviews of products they have purchased."));

            entity.Property(e => e.Productreviewid)
                .HasComment("Primary key for ProductReview records.")
                .HasColumnName("productreviewid");
            entity.Property(e => e.Comments)
                .HasMaxLength(3850)
                .HasComment("Reviewer's comments")
                .HasColumnName("comments");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(50)
                .HasComment("Reviewer's e-mail address.")
                .HasColumnName("emailaddress");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Rating)
                .HasComment("Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.")
                .HasColumnName("rating");
            entity.Property(e => e.Reviewdate)
                .HasDefaultValueSql("now()")
                .HasComment("Date review was submitted.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reviewdate");
            entity.Property(e => e.Reviewername)
                .HasMaxLength(50)
                .HasComment("Name of the reviewer.")
                .HasColumnName("reviewername");

            entity.HasOne(d => d.Product).WithMany(p => p.Productreviews)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReview_Product_ProductID");
        });

        modelBuilder.Entity<Productsubcategory>(entity =>
        {
            entity.HasKey(e => e.Productsubcategoryid).HasName("PK_ProductSubcategory_ProductSubcategoryID");

            entity.ToTable("productsubcategory", "production", tb => tb.HasComment("Product subcategories. See ProductCategory table."));

            entity.Property(e => e.Productsubcategoryid)
                .HasComment("Primary key for ProductSubcategory records.")
                .HasColumnName("productsubcategoryid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Subcategory description.")
                .HasColumnName("name");
            entity.Property(e => e.Productcategoryid)
                .HasComment("Product category identification number. Foreign key to ProductCategory.ProductCategoryID.")
                .HasColumnName("productcategoryid");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("uuid_generate_v1()")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.Productcategory).WithMany(p => p.Productsubcategories)
                .HasForeignKey(d => d.Productcategoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSubcategory_ProductCategory_ProductCategoryID");
        });

        modelBuilder.Entity<Scrapreason>(entity =>
        {
            entity.HasKey(e => e.Scrapreasonid).HasName("PK_ScrapReason_ScrapReasonID");

            entity.ToTable("scrapreason", "production", tb => tb.HasComment("Manufacturing failure reasons lookup table."));

            entity.Property(e => e.Scrapreasonid)
                .HasComment("Primary key for ScrapReason records.")
                .HasColumnName("scrapreasonid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Failure description.")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Transactionhistory>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("PK_TransactionHistory_TransactionID");

            entity.ToTable("transactionhistory", "production", tb => tb.HasComment("Record of each purchase order, sales order, or work order transaction year to date."));

            entity.Property(e => e.Transactionid)
                .HasComment("Primary key for TransactionHistory records.")
                .HasColumnName("transactionid");
            entity.Property(e => e.Actualcost)
                .HasComment("Product cost.")
                .HasColumnName("actualcost");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Quantity)
                .HasComment("Product quantity.")
                .HasColumnName("quantity");
            entity.Property(e => e.Referenceorderid)
                .HasComment("Purchase order, sales order, or work order identification number.")
                .HasColumnName("referenceorderid");
            entity.Property(e => e.Referenceorderlineid)
                .HasComment("Line number associated with the purchase order, sales order, or work order.")
                .HasColumnName("referenceorderlineid");
            entity.Property(e => e.Transactiondate)
                .HasDefaultValueSql("now()")
                .HasComment("Date and time of the transaction.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transactiondate");
            entity.Property(e => e.Transactiontype)
                .HasMaxLength(1)
                .HasComment("W = WorkOrder, S = SalesOrder, P = PurchaseOrder")
                .HasColumnName("transactiontype");

            entity.HasOne(d => d.Product).WithMany(p => p.Transactionhistories)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionHistory_Product_ProductID");
        });

        modelBuilder.Entity<Transactionhistoryarchive>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("PK_TransactionHistoryArchive_TransactionID");

            entity.ToTable("transactionhistoryarchive", "production", tb => tb.HasComment("Transactions for previous years."));

            entity.Property(e => e.Transactionid)
                .ValueGeneratedNever()
                .HasComment("Primary key for TransactionHistoryArchive records.")
                .HasColumnName("transactionid");
            entity.Property(e => e.Actualcost)
                .HasComment("Product cost.")
                .HasColumnName("actualcost");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Quantity)
                .HasComment("Product quantity.")
                .HasColumnName("quantity");
            entity.Property(e => e.Referenceorderid)
                .HasComment("Purchase order, sales order, or work order identification number.")
                .HasColumnName("referenceorderid");
            entity.Property(e => e.Referenceorderlineid)
                .HasComment("Line number associated with the purchase order, sales order, or work order.")
                .HasColumnName("referenceorderlineid");
            entity.Property(e => e.Transactiondate)
                .HasDefaultValueSql("now()")
                .HasComment("Date and time of the transaction.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transactiondate");
            entity.Property(e => e.Transactiontype)
                .HasMaxLength(1)
                .HasComment("W = Work Order, S = Sales Order, P = Purchase Order")
                .HasColumnName("transactiontype");
        });

        modelBuilder.Entity<Unitmeasure>(entity =>
        {
            entity.HasKey(e => e.Unitmeasurecode).HasName("PK_UnitMeasure_UnitMeasureCode");

            entity.ToTable("unitmeasure", "production", tb => tb.HasComment("Unit of measure lookup table."));

            entity.Property(e => e.Unitmeasurecode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Primary key.")
                .HasColumnName("unitmeasurecode");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Unit of measure description.")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Vproductanddescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vproductanddescription", "production");

            entity.Property(e => e.Cultureid)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("cultureid");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Productmodel)
                .HasMaxLength(50)
                .HasColumnName("productmodel");
        });

        modelBuilder.Entity<Vproductmodelcatalogdescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vproductmodelcatalogdescription", "production");

            entity.Property(e => e.Bikeframe)
                .HasColumnType("character varying")
                .HasColumnName("bikeframe");
            entity.Property(e => e.Color)
                .HasMaxLength(256)
                .HasColumnName("color");
            entity.Property(e => e.Copyright)
                .HasMaxLength(30)
                .HasColumnName("copyright");
            entity.Property(e => e.Crankset)
                .HasMaxLength(256)
                .HasColumnName("crankset");
            entity.Property(e => e.Maintenancedescription)
                .HasMaxLength(256)
                .HasColumnName("maintenancedescription");
            entity.Property(e => e.Manufacturer)
                .HasColumnType("character varying")
                .HasColumnName("manufacturer");
            entity.Property(e => e.Material)
                .HasMaxLength(256)
                .HasColumnName("material");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Noofyears)
                .HasMaxLength(256)
                .HasColumnName("noofyears");
            entity.Property(e => e.Pedal)
                .HasMaxLength(256)
                .HasColumnName("pedal");
            entity.Property(e => e.Pictureangle)
                .HasMaxLength(256)
                .HasColumnName("pictureangle");
            entity.Property(e => e.Picturesize)
                .HasMaxLength(256)
                .HasColumnName("picturesize");
            entity.Property(e => e.Productline)
                .HasMaxLength(256)
                .HasColumnName("productline");
            entity.Property(e => e.Productmodelid).HasColumnName("productmodelid");
            entity.Property(e => e.Productphotoid)
                .HasMaxLength(256)
                .HasColumnName("productphotoid");
            entity.Property(e => e.Producturl)
                .HasMaxLength(256)
                .HasColumnName("producturl");
            entity.Property(e => e.Riderexperience)
                .HasMaxLength(1024)
                .HasColumnName("riderexperience");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
            entity.Property(e => e.Saddle)
                .HasMaxLength(256)
                .HasColumnName("saddle");
            entity.Property(e => e.Style)
                .HasMaxLength(256)
                .HasColumnName("style");
            entity.Property(e => e.Summary).HasColumnType("character varying");
            entity.Property(e => e.Warrantydescription)
                .HasMaxLength(256)
                .HasColumnName("warrantydescription");
            entity.Property(e => e.Warrantyperiod)
                .HasMaxLength(256)
                .HasColumnName("warrantyperiod");
            entity.Property(e => e.Wheel)
                .HasMaxLength(256)
                .HasColumnName("wheel");
        });

        modelBuilder.Entity<Vproductmodelinstruction>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vproductmodelinstructions", "production");

            entity.Property(e => e.Instructions)
                .HasColumnType("character varying")
                .HasColumnName("instructions");
            entity.Property(e => e.LaborHours).HasPrecision(9, 4);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MachineHours).HasPrecision(9, 4);
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Productmodelid).HasColumnName("productmodelid");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
            entity.Property(e => e.SetupHours).HasPrecision(9, 4);
            entity.Property(e => e.Step).HasMaxLength(1024);
        });

        modelBuilder.Entity<Workorder>(entity =>
        {
            entity.HasKey(e => e.Workorderid).HasName("PK_WorkOrder_WorkOrderID");

            entity.ToTable("workorder", "production", tb => tb.HasComment("Manufacturing work orders."));

            entity.Property(e => e.Workorderid)
                .HasComment("Primary key for WorkOrder records.")
                .HasColumnName("workorderid");
            entity.Property(e => e.Duedate)
                .HasComment("Work order due date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("duedate");
            entity.Property(e => e.Enddate)
                .HasComment("Work order end date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Orderqty)
                .HasComment("Product quantity to build.")
                .HasColumnName("orderqty");
            entity.Property(e => e.Productid)
                .HasComment("Product identification number. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Scrappedqty)
                .HasComment("Quantity that failed inspection.")
                .HasColumnName("scrappedqty");
            entity.Property(e => e.Scrapreasonid)
                .HasComment("Reason for inspection failure.")
                .HasColumnName("scrapreasonid");
            entity.Property(e => e.Startdate)
                .HasComment("Work order start date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");

            entity.HasOne(d => d.Product).WithMany(p => p.Workorders)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkOrder_Product_ProductID");

            entity.HasOne(d => d.Scrapreason).WithMany(p => p.Workorders)
                .HasForeignKey(d => d.Scrapreasonid)
                .HasConstraintName("FK_WorkOrder_ScrapReason_ScrapReasonID");
        });

        modelBuilder.Entity<Workorderrouting>(entity =>
        {
            entity.HasKey(e => new { e.Workorderid, e.Productid, e.Operationsequence }).HasName("PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence");

            entity.ToTable("workorderrouting", "production", tb => tb.HasComment("Work order details."));

            entity.Property(e => e.Workorderid)
                .HasComment("Primary key. Foreign key to WorkOrder.WorkOrderID.")
                .HasColumnName("workorderid");
            entity.Property(e => e.Productid)
                .HasComment("Primary key. Foreign key to Product.ProductID.")
                .HasColumnName("productid");
            entity.Property(e => e.Operationsequence)
                .HasComment("Primary key. Indicates the manufacturing process sequence.")
                .HasColumnName("operationsequence");
            entity.Property(e => e.Actualcost)
                .HasComment("Actual manufacturing cost.")
                .HasColumnName("actualcost");
            entity.Property(e => e.Actualenddate)
                .HasComment("Actual end date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actualenddate");
            entity.Property(e => e.Actualresourcehrs)
                .HasPrecision(9, 4)
                .HasComment("Number of manufacturing hours used.")
                .HasColumnName("actualresourcehrs");
            entity.Property(e => e.Actualstartdate)
                .HasComment("Actual start date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actualstartdate");
            entity.Property(e => e.Locationid)
                .HasComment("Manufacturing location where the part is processed. Foreign key to Location.LocationID.")
                .HasColumnName("locationid");
            entity.Property(e => e.Modifieddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Plannedcost)
                .HasComment("Estimated manufacturing cost.")
                .HasColumnName("plannedcost");
            entity.Property(e => e.Scheduledenddate)
                .HasComment("Planned manufacturing end date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduledenddate");
            entity.Property(e => e.Scheduledstartdate)
                .HasComment("Planned manufacturing start date.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduledstartdate");

            entity.HasOne(d => d.Location).WithMany(p => p.Workorderroutings)
                .HasForeignKey(d => d.Locationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkOrderRouting_Location_LocationID");

            entity.HasOne(d => d.Workorder).WithMany(p => p.Workorderroutings)
                .HasForeignKey(d => d.Workorderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkOrderRouting_WorkOrder_WorkOrderID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
