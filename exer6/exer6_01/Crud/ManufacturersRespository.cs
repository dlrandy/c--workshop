using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Exer06.TalkingWithDb.Orm;

namespace Exer06.Crud
{
    public class ManufacturerRepository : IDisposable
    {
        private readonly FactoryDbContext db;
        public ManufacturerRepository(FactoryDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Manufacturer> Get()
        {
            return db.Manufacturers.Include(m => m.Products).ToList();
        }

        public IEnumerable<(string, string)> GetManufacturerAndProductNamePairs_Query()
        {
            var productAndManufacturerPairs = (from p in db.Products
                                               join m in db.Manufacturers
                                                   on p.ManufacturerId equals m.Id
                                               select new { Product = p.Name, Manufacturer = m.Name }
                ).ToList();
            return productAndManufacturerPairs.Select(p => (p.Product, p.Manufacturer));
        }

        public IEnumerable<(string, string)> GetManufacturerAndProductNamePairs_Linq()
        {
            var productAndManufacturerPairs = db.Products.Join(db.Manufacturers,

            p => p.ManufacturerId, m => m.Id, (p, m) => new { Product = p.Name, Manufacturer = m.Name }).ToList();
            return productAndManufacturerPairs.Select(p => (p.Product, p.Manufacturer));
        }


        public void Create(Manufacturer manufacturer)
        {
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}