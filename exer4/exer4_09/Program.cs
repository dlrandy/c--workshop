using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Exer04_09
{
    class Program
    {
        record CustomerOrder(string Name, string Product, int Quantity);
        record Country(string Name, string Continent, int Area);
        public static void Main()
        {

            var grades = new[] { 25, 95, 75, 40, 54, 9, 99 };
            Console.Write("Skip: Highest Grades (skipping first):");
            foreach (var grade in grades.OrderByDescending(g => g).Skip(1))
            {
                Console.Write($"{grade} ");
            }
            Console.WriteLine();
            Console.Write("SkipWhile@ Middle Grades (excluding 25 or 75)");
            foreach (var grade in grades.OrderByDescending(g => g).SkipWhile(g => g is <= 25 or >= 75))
            {
                Console.Write($"{grade} ");
            }
            Console.WriteLine();

            Console.Write("SkipLast: Bottom Half Grades:");
            foreach (var grade in grades.OrderBy(g => g).SkipLast(grades.Length / 2))
            {
                Console.Write($"{grade} ");
            }
            Console.WriteLine();

            Console.Write("Take: Two Highest Grades:");
            foreach (var grade in grades.OrderByDescending(g => g).Take(2))
            {
                Console.Write($"{grade} ");
            }

            var orders = new List<CustomerOrder>{
                new CustomerOrder("Mr Green", "LED TV", 4),
                new CustomerOrder("Mr Smith", "iPhone", 2),
                new CustomerOrder("Mrs Jones", "Printer", 1),
                new CustomerOrder("Mr Smith", "PC", 5),
                new CustomerOrder("Mr Green", "MP3 Player", 1),
                new CustomerOrder("Mr Green", "Microwave Oven", 1),
                new CustomerOrder("Mr Smith", "Printer", 2),
            };
            foreach (var grouping in orders.GroupBy(o => o.Name))
            {
                Console.WriteLine($"Customer {grouping.Key}: ");
                foreach (var item in grouping.OrderByDescending(i => i.Quantity))
                {
                    Console.WriteLine($"\t{item.Product} * {item.Quantity}");
                }
            }

            var query = from order in orders group order by order.Name;
            foreach (var grouping in query)
            {
                Console.WriteLine($"Customer {grouping.Key}");
                foreach (var item in from item in grouping orderby item.Quantity descending select item)
                {
                    Console.WriteLine($"\t {item.Product} * {item.Quantity}");
                }
            }



            //     var fileInfos = Directory.EnumerateFiles(Path.GetTempPath(), "*.tmp").Select(filename => new FileInfo(filename)).ToList();
            //     Console.WriteLine("Earliest Files");
            //     foreach (var fileInfo in fileInfos.OrderBy(fi => fi.CreationTime))
            //     {
            //         Console.WriteLine($"{fileInfo.CreationTime:dd MMM yy} {fileInfo.Name}");
            //     }
            //     Console.WriteLine("Largest Files");
            //     foreach (var fileInfo in fileInfos.OrderByDescending(fi => fi.Length))
            //     {
            //         Console.WriteLine($"{fileInfo.Length:N0} bytes:\t {fileInfo.Name}");
            //     }
            //     Console.ReadLine();
            //     Console.WriteLine("Largest smaller files");
            //     foreach (var fileInfo in from fi in fileInfos where fi.Length < 1000 orderby fi.Length descending select fi)
            //     {
            //         Console.WriteLine($"{fileInfo.Length:N0} bytes:\t {fileInfo.Name}");
            //     }

            //     var quotes = new[]{
            //         "Love for all hatred for none",
            //         "Change the world by being yourself",
            //         "Every moment is a fresh beginning",
            //         "Never regret anything that made you smile",
            //         "Die with memories not dreams",
            //         "Aspire to inspire before we expire"
            //         };

            //     foreach (var item in quotes.Select(q => new { Quote = q, Words = q.Split(" ").Length }).OrderByDescending(quotes => quotes.Words).ThenBy(quotes => quotes.Quote))
            //     {
            //         Console.WriteLine($"{item.Words}:{item.Quote}");
            //     }

            //     var query = from quote in (quotes.Select(q => new { Quote = q, Words = q.Split(" ").Length })) orderby quote.Words descending, quote.Quote ascending select quote;
            //     foreach (var item in query)
            //     {
            //         Console.WriteLine($"{item.Words} : {item.Quote}");
            //     }

            //     var countries = new[]
            //  {
            //     new Country("Seychelles", "Africa", 176),
            //     new Country("India", "Asia", 1_269_219),
            //     new Country("Brazil", "South America",3_287_956),
            //     new Country("Argentina", "South America", 1_073_500),
            //     new Country("Mexico", "South America",750_561),
            //     new Country("Peru", "South America",494_209),
            //     new Country("Algeria", "Africa", 919_595),
            //     new Country("Sudan", "Africa", 668_602)
            //  };
            //     var requiredContinents = new[] { "South America", "Africa" };
            //     var filteredCountries = countries.Where(c => requiredContinents.Contains(c.Continent)).OrderBy(c => c.Continent).ThenByDescending(c => c.Area).Select((cty, i) => new
            //     {
            //         Index = i,
            //         Country = cty
            //     });

            //     foreach (var item in filteredCountries)
            //     {
            //         Console.WriteLine($"{item.Index + 1} : {item.Country.Continent}, {item.Country.Name} = {item.Country.Area:N0} sq mi");
            //     }

        }
    }
}

