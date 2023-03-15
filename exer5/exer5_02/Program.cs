using System;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace exer05
{
    public record CarSale
    {
        public CarSale(string name, double salePrice) => (Name, SalePrice) = (name, salePrice);
        public string Name { get; }
        public double SalePrice { get; }
    }
    public interface ISalesLoader
    {
        public IEnumerable<CarSale> FetchSales();
    }
    public static class SalesAggregator
    {
        public static Task<double> Average(IEnumerable<ISalesLoader> loaders)
        {
            var loaderTasks = loaders.Select(ldr => Task.Run(ldr.FetchSales));
            return Task.WhenAll(loaderTasks).ContinueWith(tasks =>
            {
                var average = tasks.Result.SelectMany(t => t).Average(car => car.SalePrice);
                return average;
            });
        }
    }
    public class SalesLoader : ISalesLoader
    {
        private readonly Random _random;
        private readonly string _name;

        public SalesLoader(int id, Random rand)
        {
            _name = $"Loader#{id}";
            _random = rand;
        }
        public IEnumerable<CarSale> FetchSales()
        {
            var delay = _random.Next(1, 3);
            Logger.Log($"FetchSales {_name} sleeping for {delay} seconds...");
            Thread.Sleep(TimeSpan.FromSeconds(delay));
            var sales = Enumerable.Range(1, _random.Next(1, 5)).Select(n => GetRandomCar()).ToList();
            foreach (var car in sales)
            {
                Logger.Log($"FetchSales {_name} found: {car.Name} @ {car.SalePrice:N0}");
            }
            return sales;
        }
        private readonly string[] _carNames = { "Ford", "BMW", "Fiat", "Mercedes", "Porsche" };
        private CarSale GetRandomCar()
        {
            var nameIndex = _random.Next(_carNames.Length);
            return new CarSale(_carNames[nameIndex], _random.NextDouble() * 1000);
        }
    }
    class TaskWaitAnyExer
    {
        public static void Main()
        {
            Logger.Log("Starting");
            var random = new Random();
            const int MaxSalesHubs = 10;
            string input;
            do
            {

                Console.WriteLine("Max wait time (in seconds):");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var maxDelay))
                {
                    var loaders = Enumerable.Range(1, random.Next(1, MaxSalesHubs)).Select(n => new SalesLoader(n, random)).ToList();
                    var averageTask = SalesAggregator.Average(loaders);
                    var hasCompleted = averageTask.Wait(TimeSpan.FromSeconds(maxDelay));
                    var average = averageTask.Result;
                    if (hasCompleted)
                    {
                        Logger.Log($"Average={average:N0}");
                    }
                    else
                    {
                        Logger.Log("Timeout!");
                    }
                }

            } while (input != string.Empty);



        }
        public static void ContinueWith()
        {

            Logger.Log("Starting");
            Task.Run(GetStockPrice).ContinueWith(prev =>
            {

                Logger.Log($"GetPrice returned {prev.Result:N1}-{prev.Result:N2}, status={prev.Status}");
            });

            Console.WriteLine("press enter to quit");
            Console.ReadLine();
        }
        private static double GetStockPrice()
        {
            Logger.Log("Inside GetStockPrice");
            Thread.Sleep(TimeSpan.FromSeconds(2D));
            return new Random().NextDouble() * 100D;
        }
        public static void WaitAll()
        {

            Logger.Log("Starting");

            var taskA = Task.Run(() =>
            {
                Logger.Log("inside taskA");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Logger.Log("Leaving TaskA");
                return "All done A";
            });
            var taskB = Task.Run(TaskBActivity);
            var taskC = Task.Run(TaskCActivity);

            var timeout = TimeSpan.FromSeconds(new Random().Next(1, 10));
            Logger.Log($"waiting max {timeout.TotalSeconds} seconds...");
            var allDone = Task.WaitAll(new[] { taskA, taskB, taskC }, timeout);

            Logger.Log($"AllDone={allDone}: TaskA={taskA.Status},TaskB={taskB.Status},TaskC={taskC.Status}");
            Console.WriteLine("press enter to quit");
            Console.ReadLine();
        }
        public void WaitAny()
        {
            var outerTask = Task.Run(() =>
            {
                Logger.Log("Inside outerTask");
                var inner1 = Task.Run(() =>
                {
                    Logger.Log("inside inner1");
                    Thread.Sleep(TimeSpan.FromSeconds(3D));
                });
                var inner2 = Task.Run(() =>
                {
                    Logger.Log("inside inner2");
                    Thread.Sleep(TimeSpan.FromSeconds(2D));
                });
                Logger.Log("calling waitany on outerTask");
                var doneIndex = Task.WaitAny(inner1, inner2);
                Logger.Log($"waitany index={doneIndex}");
            });
            Logger.Log("press enter");
            Console.ReadLine();
        }
        private static string TaskBActivity()
        {
            Logger.Log($"Inside {nameof(TaskBActivity)}");
            Thread.Sleep(TimeSpan.FromSeconds(2D));
            Logger.Log($"Inside {nameof(TaskBActivity)}");
            return "";
        }
        private static string TaskCActivity()
        {
            Logger.Log($"Inside {nameof(TaskCActivity)}");
            Thread.Sleep(TimeSpan.FromSeconds(1D));
            Logger.Log($"Inside {nameof(TaskCActivity)}");
            return "";
        }
    }
}