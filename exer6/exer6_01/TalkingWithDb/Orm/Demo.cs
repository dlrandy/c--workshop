using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Exer06.TalkingWithDb.Orm
{
    public static class Demo
    {
        public static void Run()
        {
            using var context = new FactoryDbContext();
            if (context.Manufacturers == null)
            {
                return;
            }
            var manufacturers = context.Manufacturers.Include(p => p.Products).ToList();
            foreach (var manufacturer in manufacturers)
            {
                foreach (var product in manufacturer.Products)
                {
                    Console.WriteLine($"{manufacturer.Name} {product.Name} {product.Id} {product.Price}");
                }
            }
        }
    }
}