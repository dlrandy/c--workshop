using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exer05
{
    public enum RegionName { North, East, South, West };
    public class Customer
    {
        private readonly RegionName _protectedRegion;
        public string Name { get; }
        public RegionName Region { get; }
        public Customer(string name, RegionName region, RegionName protectedRegion)
        {
            Name = name;
            Region = region;
            _protectedRegion = protectedRegion;
        }
        private int _totalOrders;
        public int TotalOrders
        {
            get
            {
                if (Region == _protectedRegion)
                {
                    throw new AccessViolationException($"Cannot access orders for {Name}");
                }
                return _totalOrders;
            }
            set => _totalOrders = value;
        }
    }
    public class Program
    {
        private static IEnumerable<Task<int>> CreateBadTasks(string info)
        {
            return Enumerable.Range(0, 5).Select(i => BadTask(info, i)).ToList();
        }
        private static async Task<int> BadTask(string info, int n)
        {
            await Task.Delay(1000);
            Logger.Log($"{info} number {n} awake");
            if (n % 2 == 0)
            {
                Logger.Log($"About to throw one {info} number {n}");
                throw new InvalidOperationException($"oh dear from {info} number {n}");
            }
            return n;
        }
        public static async Task Main()
        {
            Logger.Log("Fetching task quotes...");
            var taskQuotes = await GetInsuranceQuotesAsTask();
            foreach (var quote in taskQuotes)
            {
                Logger.Log($"Received Task:{quote}");
            }

            Logger.Log("Fetching Stream quotes...");
            await foreach (var quote in GetInsuranceQuotesAsTaskAsync())
            {
                Logger.Log($"Received Stream: {quote}");
            }
            Logger.Log("All Done");
          
        }
        public static async Task<IEnumerable<string>> GetInsuranceQuotesAsTask(){
            var rand = new Random();
            var quotes = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                quotes.Add($"Provider{i}'s quote is {rand.Next(5,10)}");
            }
            return quotes;
        }
        public static async IAsyncEnumerable<string> GetInsuranceQuotesAsTaskAsync(){
            var rand = new Random();
            var quotes = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                yield return $"Provider{i}'s quote is {rand.Next(5,10)}";
            }
             
        }
        public static async Task Main6()
        {
            var whenAnyCompletedTask = Task.WhenAny(CreateBadTasks("[WhenAny]"));
            try
            {
                var result = await whenAnyCompletedTask;
                Logger.Log($"WhenAny result: {result.Result}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"WhenAny Caught {ex.GetType().Name}, Message={ex.Message}");
            }
          
        }
        public static async Task Main3()
        {
            var whenAllCompletedTask = Task.WhenAll(CreateBadTasks("[WhenAll]"));
            try
            {
                await whenAllCompletedTask;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"WhenAll Caught {ex.GetType().Name}, Message={ex.Message}");
            }
            Console.WriteLine($"whenAll Task.Status={whenAllCompletedTask.Status}");
            foreach (var ie in whenAllCompletedTask.Exception.InnerExceptions)
            {
                Console.WriteLine($"whenAll Caught Inner Exception {ie.Message}");
            }
        }
        public static async Task Main2()
        {
            var ops = new CustomerOperations();
            var resultTask = ops.FetchTopCustomers();
            var customers = await resultTask;
            foreach (var customer in customers)
            {
                Logger.Log($"{customer.Name} ({customer.Region}):{customer.TotalOrders:N0}");
            }
        }
    }
    public class CustomerOperations
    {
        public const RegionName ProtectedRegion = RegionName.West;
        public async Task<IEnumerable<Customer>> FetchTopCustomers()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            Logger.Log("Load customers...");
            var customers = new List<Customer>
            {
                new Customer("Rick Deckard", RegionName.North,
                ProtectedRegion),
                new Customer("Taffey Lewis", RegionName.North,
                ProtectedRegion),
                new Customer("Rachael", RegionName.North,
                ProtectedRegion),
                new Customer("Roy Batty", RegionName.West,
                ProtectedRegion),
                new Customer("Eldon Tyrell", RegionName.East,
                ProtectedRegion)
            };
            await FetchOrders(customers);
            var filteredCustomers = new List<Customer>();
            foreach (var customer in customers)
            {
                try
                {
                    if (customer.TotalOrders > 0)
                    {
                        filteredCustomers.Add(customer);
                    }
                }
                catch (AccessViolationException e)
                {

                    Logger.Log($"Error {e.Message}");
                }
            }
            return filteredCustomers.OrderByDescending(c => c.TotalOrders);
        }
        private async Task FetchOrders(IEnumerable<Customer> customers)
        {
            var rand = new Random();
            Logger.Log("Loading orders...");
            var orderUpdateTasks = customers.Select(
                cust => Task.Run(async () =>
                {
                    await Task.Delay(500);
                    cust.TotalOrders = rand.Next(1, 100);
                })
            ).ToList();
            await Task.WhenAll(orderUpdateTasks);
        }
    }

}