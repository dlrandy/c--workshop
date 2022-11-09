using System;
using System.IO;
using System.Threading.Tasks;
namespace exer1_10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool divisionExecuted = false;
            while (!divisionExecuted)
            {
                try
                {
                    Console.WriteLine("Please input a number");
                    var a = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Please input another number");
                    var b = int.Parse(Console.ReadLine()!);
                    var res = Divide(a, b);
                    Console.WriteLine($"Result: [{res}]");
                    divisionExecuted = true;
                }
                catch (System.FormatException)
                {

                    Console.WriteLine("You did not input a number. Let's start again... \n");
                    continue;
                }
                catch (System.DivideByZeroException)
                {

                    Console.WriteLine("Tried to divide by zero. Let's start again ... \n");
                    continue;
                }
            }
        }
        static double Divide(int a, int b)
        {
            return a / b;
        }
        public static async Task WriteFile()
        {

            using (var file = new StreamWriter("exer1_10/products.csv", append: true))
            {
                file.Write("\n One more macbook without details");
            }
            await ReadFile();

        }
        public static async Task ReadFile()
        {
            using (var fileStream = new FileStream("exer1_10/products.csv",
            FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    var content = await reader.ReadToEndAsync();
                    var lines = content.Split(Environment.NewLine);
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }

    class Person
    {
        Person(string name){
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
                Name = name;
            }
        }
        String Name {get; set;}
    }

}