using System;
using System.Collections.Generic;
using System.Linq;
using Exer06.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exer6_01.GlobalFactory2021
{
    public static class Demo
    {
        public static void Run()
        {
            DataSeeding.SeedDataNotSeededBefore();
            CompareExecTimes(EnumerableVSQueryable.Slow, EnumerableVSQueryable.Fast, "IEnumerable over IQueryable");
            CompareExecTimes(MethodChoice.Slow, MethodChoice.Fast, "equals over ==");
            CompareExecTimes(Loading.Lazy, Loading.Eager, "Lazy over Eager loading");
            CompareExecTimes(LightweightEf.Default, LightweightEf.AsNoTracking, "AsNoTracking for many readonly entities");
            CompareExecTimes(MultipleAddsOrRemoves.Slow, MultipleAddsOrRemoves.Fast, "Add over AddRange");
        }
        private static void CompareExecTimes(Action slow, Action fast, string scenarioLabel)
        {
            var sw = new Stopwatch();
            sw.Start();
            slow();
            sw.Stop();
            var slowTime = sw.ElapsedMilliseconds;
            sw.Restart();
            fast();
            sw.Stop();
            var fastTime = sw.ElapsedMilliseconds;
            Console.WriteLine("{0,-40} Scenario1:{1,-7} Scenario2: {2}",
                scenarioLabel.ToUpper(),
                slowTime + "ms,", fastTime + "ms");
        }
        public static void Run1()
        {
            var db = new Globalfactory2021Context();
            var manufacturer = new Manufacturer
            {
                Country = "Canada",
                FoundedAt = DateTime.UtcNow,
                Name = "Fake Toys"
            };

            var product = new Product
            {
                Name = "Rubber Sweater",
                Manufacturer = manufacturer
            };

            var priceHistory = new List<ProductPriceHistory>
            {
                new ProductPriceHistory
                {
                    DateOfPrice = DateTime.UtcNow.AddDays(-10),
                    Price = 15.11m,
                    Product = product
                },
                new ProductPriceHistory
                {
                    DateOfPrice = DateTime.UtcNow,
                    Price = 15.5m,
                    Product = product
                }
            };

            product.PriceHistory = priceHistory;
            manufacturer.Products = new List<Product> { product };

            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();

            db.Dispose();

            db = new Globalfactory2021Context();
            var manufacturerAfterAddition = db.Manufacturers
                .Include(m => m.Products)
                .ThenInclude(p => p.PriceHistory)
                .First(m => m.Name == "Fake Toys");

            var productAfterAddition = manufacturerAfterAddition.Products.First();

            Console.WriteLine($"{manufacturerAfterAddition.Name} {productAfterAddition.Name} {productAfterAddition.GetPrice()}");
            db.Dispose();
        }

    }
}