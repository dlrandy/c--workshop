using System.Collections.Generic;
using Exer06.TalkingWithDb.Orm;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Exer06.Repo
{
    public static class Demo
    {
        public static void Run()
        {
            var db = new FactoryDbContext();
            var manufacturerRepository = new Repository<Manufacturer>(db);
            var manufacturer = new Manufacturer { Country = "LILILIL", Name = "LALALLA" };
            var id = manufacturerRepository.Create(manufacturer);
            manufacturer.Name = "new Name";
            manufacturerRepository.Update(manufacturer);

            var manufacturerAfterChanges = manufacturerRepository.Get(id);
            Console.WriteLine($"Id: {manufacturerAfterChanges.Id}" + $"Name: {manufacturerAfterChanges.Name}");

            var countBeforeDelete = manufacturerRepository.Get().Count();
            manufacturerRepository.Delete(id);
            var countAfter = manufacturerRepository.Get().Count();
            Console.WriteLine($"Before: {countBeforeDelete}, after: {countAfter}");
        }
    }
}