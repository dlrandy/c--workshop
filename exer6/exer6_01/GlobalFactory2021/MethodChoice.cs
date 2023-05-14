using System;
using System.Collections.Generic;
using System.Linq;

namespace exer6_01.GlobalFactory2021;

public partial class MethodChoice
{
    public static void Slow()
    {
        var db = new Globalfactory2021Context();
        // ef 只能将一些操作转换为sql
        var filtered = db.Products.Where(p => p.Name.Equals(DataSeeding.TestProduct1Name)).ToList();

        db.Dispose();
    }
    public static void Fast()
    {
        var db = new Globalfactory2021Context();
        var filtered = db.Products.Where(p => p.Name == DataSeeding.TestProduct1Name).ToList();
        db.Dispose();
    }

}