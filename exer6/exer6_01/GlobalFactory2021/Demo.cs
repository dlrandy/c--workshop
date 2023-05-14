using System;
using System.Collections.Generic;
using System.Linq;
using Exer06.TalkingWithDb.Orm;
using Microsoft.EntityFrameworkCore;

namespace exer6_01.GlobalFactory2021
{
    public static class Demo
    {
        public static void Run(){
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