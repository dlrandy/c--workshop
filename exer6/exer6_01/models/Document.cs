using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Product maintenance documents.
/// </summary>
public partial class Document
{
    /// <summary>
    /// Title of the document.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Employee who controls the document.  Foreign key to Employee.BusinessEntityID
    /// </summary>
    public int Owner { get; set; }

    /// <summary>
    /// 0 = This is a folder, 1 = This is a document.
    /// </summary>
    public bool Folderflag { get; set; }

    /// <summary>
    /// File name of the document
    /// </summary>
    public string Filename { get; set; } = null!;

    /// <summary>
    /// File extension indicating the document type. For example, .doc or .txt.
    /// </summary>
    public string? Fileextension { get; set; }

    /// <summary>
    /// Revision number of the document.
    /// </summary>
    public string Revision { get; set; } = null!;

    /// <summary>
    /// Engineering change approval number.
    /// </summary>
    public int Changenumber { get; set; }

    /// <summary>
    /// 1 = Pending approval, 2 = Approved, 3 = Obsolete
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Document abstract.
    /// </summary>
    public string? Documentsummary { get; set; }

    /// <summary>
    /// Complete document.
    /// </summary>
    public byte[]? Document1 { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Required for FileStream.
    /// </summary>
    public Guid Rowguid { get; set; }

    public DateTime Modifieddate { get; set; }

    /// <summary>
    /// Primary key for Document records.
    /// </summary>
    public string Documentnode { get; set; } = null!;

    public virtual ICollection<Productdocument> Productdocuments { get; set; } = new List<Productdocument>();
}
