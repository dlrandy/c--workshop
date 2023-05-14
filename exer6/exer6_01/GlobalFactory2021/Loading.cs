using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace exer6_01.GlobalFactory2021;

public partial class Loading
{
    public static void Lazy()
    {
        var db = new Globalfactory2021Context();
        var product = db.Products.First();
        var manufacturer = product.Manufacturer;
        db.Dispose();
    }
    public static void Eager()
    {
        var db = new Globalfactory2021Context();
        var manufacturer = db.Products
        // eager loading
        .Include(p => p.Manufacturer).First().Manufacturer;
        db.Dispose();
    }
}