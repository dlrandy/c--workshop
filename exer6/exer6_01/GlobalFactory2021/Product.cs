using System;
using System.Collections.Generic;

namespace exer6_01.GlobalFactory2021;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    // public decimal Price { get; set; }
    public decimal GetPrice() => PriceHistory
            .Where(p => p.ProductId == Id).OrderByDescending(p => p.DateOfPrice).First().Price;
    public ICollection<ProductPriceHistory> PriceHistory { get; set; }

    public int Manufacturerid { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

}
