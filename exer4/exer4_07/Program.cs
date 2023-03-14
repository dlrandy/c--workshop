using System;
using System.Collections.Generic;
using System.Linq;

namespace Exer04_07
{
    class LinqSelect
    {
        record City(string Name, IEnumerable<string> Stations);
        static void LinqSelectMany()
        {
            var cities = new List<City>{
                new City("London", new [] {"Kings Cross KGX", "Liverpool Street LVS", "Euston EUS"}),
                new City("Birmingham", new [] {"New Street NST"}),
            };
            Console.WriteLine("All Stations:");
            foreach (var station in cities.SelectMany(city => city.Stations))
            {
                Console.WriteLine(station);
            }
            Console.Write("All Station Codes: ");
            var stations = cities.SelectMany(city => city.Stations.Select(s => s[^3..]));
            foreach (var station in stations)
            {
                Console.Write($"{station} ");
            }
            Console.ReadLine();

        }
        public static void Main()
        {
            var days = new List<string> { "mon", "Tues", "Wednes" };
            var query1 = days.Select(d => d + "day");
            foreach (var day in query1)
            {
                Console.WriteLine($"Query1: {day}");
            }

            var query2 = days.Select((d, i) => $"{i} : {d} day");
            foreach (var day in query2)
            {
                Console.WriteLine($"Query2: {day}");
            }

            var query3 = days.Select((d, i) => new
            {
                Index = i,
                UpperCaseName = $"{d.ToUpper()} DAY"
            });
            foreach (var day in query3)
            {
                Console.WriteLine($"Query3: Index={day.Index}, UpperCaseDay={day.UpperCaseName}");
            }

            var query4 = from day in days select day + "day";
            foreach (var day in query4)
            {
                Console.WriteLine($"Query4: {day}");
            }

            var query5 = from dayIndex in days.Select((d, i) => new
            {
                Name = d,
                Index = i
            })
                         select dayIndex;
            foreach (var day in query5)
            {
                Console.WriteLine($"Query5: Index={day.Index} : {day.Name}");
            }
            Console.ReadLine();
            LinqSelectMany();
        }
    }
}



