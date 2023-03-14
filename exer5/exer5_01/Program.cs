using System;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
namespace exer05
{
    class TaskExamples
    {
        public static void Main()
        {
            // Logger.Log("creating taskA");
            // var taskA = new Task(() =>
            // {
            //     Logger.Log("Inside taskA");
            //     Thread.Sleep(TimeSpan.FromSeconds(5D));
            //     Logger.Log("Leaving taskA");
            // });
            // Logger.Log($"Starting taskA. Status={taskA.Status}");
            // taskA.Start();
            // Logger.Log($"Starting taskA. Status={taskA.Status}");
            // Console.ReadLine();

            // var taskB = Task.Factory.StartNew(() =>
            // {
            //     Logger.Log("Inside taskB");
            //     Thread.Sleep(TimeSpan.FromSeconds(3D));
            //     Logger.Log("Leaving taskB");
            // });
            // Logger.Log($"Starting taskB. Status={taskB.Status}");
            // Console.ReadLine();
            // var taskC = Task.Run(() =>
            // {
            //     Logger.Log("Inside taskC");
            //     Thread.Sleep(TimeSpan.FromSeconds(1D));
            //     Logger.Log("Leaving taskC");
            // });
            // Logger.Log($"Starting taskC. Status={taskC.Status}");
            // Console.ReadLine();
            string input;
            do
            {
                Console.WriteLine("Enter number:");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out var number))
                {
                    var now = DateTime.Now;
                    var fib = Fibonacci(number);
                    var duration = DateTime.Now.Subtract(now);
                    Logger.Log($"Fibonacci {number:N0} = {fib:N0} (elapsed time: {duration.TotalSeconds:N0} secs)");
                }
            } while (input != string.Empty);
        }
        private static long Fibonacci(int n){
            if (n <= 2L)
            {
                return 1L;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}