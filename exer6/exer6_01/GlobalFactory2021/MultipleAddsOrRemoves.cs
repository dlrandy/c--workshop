using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exer6_01.GlobalFactory2021;

public partial class MultipleAddsOrRemoves
{

    public static void Slow()
    {
        var db = new Globalfactory2021Context();
        var productName = "DummyP";
        for (int i = 0; i < 1000; i++)
        {
            var product = new Product
            {
                Name = productName,
                Manufacturerid = 2,
            };
            db.Products.Add(product);
        }
        var toRemoves = db.Products.Where(p => p.Name == productName).ToList();
        foreach (var toRemove in toRemoves)
        {
            db.Products.Remove(toRemove);
        }
        db.Dispose();

    }
    public static void Fast() {
        var db = new Globalfactory2021Context();
        var productName = "DummyP";
        var toAdd = new List<Product>();
        for (int i = 0; i < 1000; i++)
        {
            var product = new Product{
                Name = productName,
                Manufacturerid = 2,
            };
            toAdd.Add(product);
        }
        db.Products.AddRange(toAdd);
        var toRemoves = db.Products.Where(p => p.Name == productName).ToList();
        db.Products.RemoveRange(toRemoves);
        db.Dispose();
     }
}