using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exer6_01.GlobalFactory2021;

public partial class EnumerableVSQueryable
{
    public static void Slow()
    {
        var db = new Globalfactory2021Context();
        // 在将DbSet<Product>赋值给Ienumerable<Product>的时候，是会select所有的Product的
        IEnumerable<Product> products = db.Products;
        var filtered = products.Where(p => p.Name == DataSeeding.TestProduct1Name).ToList();
        db.Dispose();
    }
    public static void Fast()
    {
        var db = new Globalfactory2021Context();
        // IQueryable is a data structure still able to translate a C# expression to a SQL query.
        // SQL is much faster for lookups than C#.
        // 10 times faster.会在toList之后转换成一个sql
        IQueryable<Product> products = db.Products;
        var filtered = products.Where(p => p.Name == DataSeeding.TestProduct1Name).ToList();
        db.Dispose();


    }
}