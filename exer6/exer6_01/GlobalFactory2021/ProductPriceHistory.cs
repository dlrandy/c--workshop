using System;
using System.Collections.Generic;

namespace exer6_01.GlobalFactory2021;
public partial class ProductPriceHistory
{
 public int Id { get; set; }
 public decimal Price { get; set; }
 public DateTime DateOfPrice { get; set; }
 public int ProductId { get; set; }
 public Product Product { get; set; }
}