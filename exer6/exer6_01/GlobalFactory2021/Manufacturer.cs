using System;
using System.Collections.Generic;

namespace exer6_01.GlobalFactory2021;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
