using System;
using System.Collections.Generic;

namespace exer04.Examples
{
    class LisExamples
    {
        public static void Main()
        {
            var colors = new List<string> { "red", "green" };
            colors.Add("orange");
            colors.AddRange(new[] { "yellow", "pink" });
            Console.WriteLine($"Colors has {colors.Count} items");
            Console.WriteLine($"Item at index 1 is {colors[1]}");
            Console.WriteLine("Inserting blue at 0");
            colors.Insert(0, "blue");
            Console.WriteLine($"Item at index 1 is now {colors[1]}");
            Console.WriteLine("foreach");
            foreach (string color in colors)
            {
                Console.Write($"{color}|");
            }
            Console.WriteLine();
            Console.WriteLine("Foreach action");
            colors.ForEach(color =>
            {
                var characters = color.ToCharArray();
                Array.Reverse(characters);
                var reversed = new string(characters);
                Console.Write($"{reversed}|");
            });
            Console.WriteLine();
            var backupColors = new List<string>(colors);
            backupColors.Sort();

            colors.AddRange(backupColors);
            Console.WriteLine("foreach after addrange (sorted items):");
            foreach (var color in colors)
            {
                Console.Write($"{color}|");
            }
            Console.WriteLine();
            var indexes = colors.ConvertAll(color => $"{color} is at index {colors.IndexOf(color)}");
            Console.WriteLine("ConvertAll:");

            Console.WriteLine(string.Join(Environment.NewLine, indexes));

            Console.WriteLine($"Contains RED: {colors.Contains("RED")}");
            Console.WriteLine($"Contains red: {colors.Contains("red")}");
            var existsInk = colors.Exists(color => color.EndsWith("ink"));
            Console.WriteLine($"Exists *ink: {existsInk}");

            Console.WriteLine("Inserting reds");
            colors.InsertRange(0, new [] {"red", "red"});

            foreach (var color in colors)
            {
                Console.Write($"{color}|");
            }
            Console.WriteLine();


            var allReds = colors.FindAll(color => color == "red");
            Console.WriteLine($"Found {allReds.Count} red");

        colors.Remove("red");
        var lastRedIndex = colors.FindLastIndex(color => color == "red");
        Console.WriteLine($"Last red found at index {lastRedIndex}");
        Console.ReadLine();





        }
    }
}