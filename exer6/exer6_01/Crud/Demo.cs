using System;
using System.Collections.Generic;
using System.Linq;
using Exer06.TalkingWithDb.Orm;
namespace Exer06.Crud
{
    public static class Demo
    {
        public static void Run(){
            var dbContext = new FactoryDbContext();
            var productsRepo = new ProductRepository(dbContext);
            productsRepo.Create(new Product {Name = "Test1", ManufacturerId = 3});
            productsRepo.Create(new Product {Name = "Test2", ManufacturerId = 3});
            productsRepo.Create(new Product {Name = "Test3", ManufacturerId = 3});
            var productByName = productsRepo.GetByName("Test1");
            var productById = productsRepo.GetById(productByName.Id);
            Console.WriteLine($"{productById.Id} {productById.Name}");
            productsRepo.Delete("Test2");
            productsRepo.Delete(productById.Id);
            productById = productsRepo.GetByName("Test3");
            productsRepo.DeleteDirectly(productById.Id);

            var manufacturerRepo = new ManufacturerRepository(dbContext);
            manufacturerRepo.Create(new Manufacturer {Name = "TestManufacturer", Country = "Country"});
            var manufacturers = manufacturerRepo.GetManufacturerAndProductNamePairs_Linq();
            PrintManufacturersAndProducts(manufacturers);
            manufacturers = manufacturerRepo.GetManufacturerAndProductNamePairs_Query();
            PrintManufacturersAndProducts(manufacturers);
            dbContext.Dispose();

        }
        private static void PrintManufacturersAndProducts(IEnumerable<(string, string)> kvp){
            foreach (var kpv1 in kvp)
            {
                Console.WriteLine(kpv1);
            }
        }
    }
}