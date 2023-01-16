using System;
using System.Collections.Generic;

namespace Exer04_05
{
    public record Country(string Name) { }

    class Program
    {
        public static void Main()
        {
            var countries = new Dictionary<string, Country>{
                {"AFG", new Country("Afghanistan")},
                {"ALB", new Country("Albania")},
                {"DZA", new Country("Algeria")},
                {"ASM", new Country("American Samoa")},
                {"AND", new Country("Andorra")}
            };
            Console.WriteLine("Enumerate foreach KeyValuePair");
            foreach (var kvp in countries)
            {
                Console.WriteLine($"\t{kvp.Key} = {kvp.Value.Name}");
            }
            Console.WriteLine("set index of AFG to new Value");
            countries["AFG"] = new Country("ASFFFFGGGG");
            Console.WriteLine($"get index of AFG: {countries["AFG"].Name}");
            Console.WriteLine($"ContainsKey {"AGO"}: {countries.ContainsKey("AGO")}");
            Console.WriteLine($"ContainsKey {"and"}: {countries.ContainsKey("and")}");

            var anguilla = new Country("Anguilla");
            Console.WriteLine($"Add {anguilla}...");
            countries.Add("AIA", anguilla);
            try
            {
                var anguillaCopy = new Country("Anguilla");
                Console.WriteLine($"Add {anguillaCopy}...");
                countries.Add("AIA", anguillaCopy);
            }
            catch (System.Exception e)
            {
                
               Console.WriteLine($"Caught {e.Message}");
            }


            var tryGet = countries.TryGetValue("ALB", out Country albanial);
            Console.WriteLine($"TryGetValue for ALB: {albanial} result={tryGet}");
        }


    }
}