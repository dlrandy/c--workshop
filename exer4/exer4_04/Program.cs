using System;
using System.Collections.Generic;


namespace Exer04_04{
    class HashSetExer
    {
        public static void Main(){
            var actors = new List<string> {"harrison Ford", "Will Smith"};
            var singers = new List<string> {"Will Smith", "Adele"};
            var actingOrSing = new HashSet<string>(singers);
            actingOrSing.UnionWith(actors);
            Console.WriteLine($"Acting or sing: {string.Join(", ", actingOrSing)}");

            var actingAndSing = new HashSet<string>(singers);
            actingAndSing.IntersectWith(actors);
            Console.WriteLine($"Acting and Sing: {string.Join(", ", actingAndSing)}");

        var actingOnly = new HashSet<string>(actors);
        actingOnly.ExceptWith(singers);
        Console.WriteLine($"Acting only:{string.Join(", ", actingOnly)}");
        Console.ReadLine();

        }
    }
}