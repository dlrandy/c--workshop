using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exer06.activity
{

    public static class Demo
    {
        public static void Run()
        {
            var db = new TruckDispatchDbContext();
            SeedData(db);
            var dispatches = GetAll(db);
            Print(dispatches);
            db.Dispose();
        }
        private static void SeedData(TruckDispatchDbContext db)
        {
            var wasSeeded = db.Trunks.Any();
            if (!wasSeeded)
            {
                var person = new Person
                {
                    DoB = DateTime.UtcNow,
                    Id = 1,
                    Name = "A la king",
                };
                db.People.Add(person);
                var truck = new Truck
                {
                    Id = 1,
                    Brand = "Scania",
                    Model = "R 500 LA6x2HHA",
                    YearOfMaking = 2009
                };
                 db.Trunks.Add(truck);

                var dispatch = new TruckDispatch()
                {
                    CurrentLocation = "1,1,1",
                    Deadline = DateTime.UtcNow.AddDays(100),
                    Driver = person,
                    Truck = truck
                };
                db.TrunkDispatches.Add(dispatch);

                db.SaveChanges();
            }

        }
        private static IEnumerable<TruckDispatch> GetAll(TruckDispatchDbContext db)
        {
            var dispatches = db.TrunkDispatches.Include(td => td.Driver).Include(td => td.Truck).ToList();
            return dispatches;
        }
        private static void Print(IEnumerable<TruckDispatch> truckDispatches)
        {
            foreach (var dispatch in truckDispatches)
            {
                Console.WriteLine($"Dispatch: {dispatch.Id} {dispatch.CurrentLocation} {dispatch.Deadline}");
                Console.WriteLine($"Driver: {dispatch.Driver.Name} {dispatch.Driver.DoB}");
                Console.WriteLine($"Truck: {dispatch.Truck.Brand} {dispatch.Truck.Model} {dispatch.Truck.YearOfMaking}");
            }
        }
    }


}