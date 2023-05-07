using System;
using System.Collections.Generic;

namespace exer6_01.models;

/// <summary>
/// Customer reviews of products they have purchased.
/// </summary>
public partial class Productreview
{
    /// <summary>
    /// Primary key for ProductReview records.
    /// </summary>
    public int Productreviewid { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Name of the reviewer.
    /// </summary>
    public string Reviewername { get; set; } = null!;

    /// <summary>
    /// Date review was submitted.
    /// </summary>
    public DateTime Reviewdate { get; set; }

    /// <summary>
    /// Reviewer&apos;s e-mail address.
    /// </summary>
    public string Emailaddress { get; set; } = null!;

    /// <summary>
    /// Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Reviewer&apos;s comments
    /// </summary>
    public string? Comments { get; set; }

    public DateTime Modifieddate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
