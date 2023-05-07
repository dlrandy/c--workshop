using System;
using System.Collections.Generic;

namespace exer6_01.GlobalFactory2021;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Manufacturerid { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;
}
