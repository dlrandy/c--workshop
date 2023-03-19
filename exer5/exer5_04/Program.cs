using System;
using System.Threading;
using System.Threading.Tasks;

namespace exer05
{
    class Program
    {
        public static async Task Main()
        {
           try
           {
            var operations = new CustomerOperations();
            var discount = await operations.AverageDiscount();
            Logger.Log($"Discount: {discount}");
           }
           catch (DivideByZeroException ex)
           {
            
            Console.WriteLine("Caught a divide by zero");
           }
        }

        class CustomerOperations
        {
            public async Task<int> AverageDiscount(){
                Logger.Log("Loading orders...");
                await Task.Delay(TimeSpan.FromSeconds(1));
                var orderCount = new Random().Next(0,2);
                var orderValue = 1200;
                return orderValue / orderCount;
            }
        }
        public static void Main2()
        {
            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                Logger.Log($"Caught UnobservedTaskException: {args.Exception}");
            };
            var ops = new FireAndForgetOperations();
            ops.DoStuff();
            ops.DoStuffTask();
            // await ops.DoStuffTask();
            ops = null;
            GC.Collect();
        }
    }
    class FireAndForgetOperations
    {
        public void DoStuff()
        {
            Task.Run(BadOperation);
        }
        public Task DoStuffTask()
        {
            return Task.Run(BadOperation);
        }
        private static void BadOperation()
        {
            Logger.Log("BadOperation sleeping...");
            Thread.Sleep(1000);
            Logger.Log("BadOperation awake, throwing...");
            throw new ApplicationException("oops");
        }
    }
}