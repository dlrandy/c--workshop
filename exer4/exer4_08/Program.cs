using System;
using System.Collections.Generic;
using System.Linq;

namespace Exer04_08
{
    record Order(string Product, int Quantity, double Price);
    record TravelLog (string Name, int Distance, int Duration) {
        public double AverageSpeed(){
            Console.WriteLine($"AverageSpeed() called for '{Name}'");
            return Distance / Duration;
        }
    }
    class Program
    {
        public static void Main()
        {
            var orders = new List<Order>{
                new Order("Pen", 33, 2.32),
                new Order("Pencil", 5, 3.44),
                new Order("Note Pad", 1, 2.33),
            };
            Console.WriteLine("Orders with quantity over 5:");
            foreach (var order in orders.Where(o => o.Quantity > 5))
            {
                Console.WriteLine(order);
            }
            Console.WriteLine("Pens or Pencils");
            foreach (var orderValue in orders.Where(o => o.Product == "Pen" || o.Product == "Pencil").Select(o => o.Quantity * o.Price))
            {
                Console.WriteLine(orderValue);
            }


            var query = from order in orders where order.Price <= 3.99 select new { Name = order.Product, Value = order.Quantity * order.Price };
            Console.WriteLine("Cheapest Orders:");
            foreach (var order in query)
            {
                Console.WriteLine($"{order.Name} : {order.Value}");
            }

            var travelLogs = new List<TravelLog>{
                new TravelLog("London to Brighton", 50,4),
                new TravelLog("Newcastle to London", 300,24),
                new TravelLog("NewYork to Florida", 1146,19),
                new TravelLog("Paris to Berlin", 546 ,10),
            };
            var fastestJourneys = travelLogs.Where(tl => tl.AverageSpeed() > 50);
            Console.WriteLine("Fastest Distances:");
            foreach (var item in fastestJourneys)
            {
                Console.WriteLine($"{item.Name}: {item.Distance} miles");
            }


        }
    }
}