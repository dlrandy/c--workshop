using System;
using System.Collections.Generic;
namespace exer03_08
{
    public class AlarmClock
    {
        public event EventHandler WakeUp = delegate { };
        public event EventHandler<DateTime> Ticked = delegate { };

        protected void OnWakeUp()
        {
            WakeUp.Invoke(this, EventArgs.Empty);
        }

        public DateTime AlarmTime { get; set; }
        public DateTime ClockTime { get; set; }
        public void Start()
        {
            const int MinutesInADay = 60 * 24;
            for (int i = 0; i < MinutesInADay; i++)
            {
                ClockTime = ClockTime.AddMinutes(1);
                Ticked.Invoke(this, ClockTime);
                var timeRemaining = ClockTime.Subtract(AlarmTime).TotalMinutes;
                if (IsTimeToWakeUp(timeRemaining))
                {
                    OnWakeUp();
                    break;
                }
            }
        }
        static bool IsTimeToWakeUp(double timeRemaining) => timeRemaining is (>= -1.0 and <= 1.0);
    }

    public static class Program
    {
        public static void Main()
        {
            var clock = new AlarmClock();
            // clock.Ticked += ClockTicked;
            // clock.WakeUp += ClockWakeUp;

            clock.Ticked += (sender, e) =>
            {
                Console.Write($"{e:t}...");
            };
            clock.WakeUp += (sender, e) =>
            {
                Console.WriteLine();
                Console.WriteLine("WakeUp");
            };

            clock.ClockTime = DateTime.Now;
            clock.AlarmTime = DateTime.Now.AddMinutes(120);
            Console.WriteLine($"ClockTime={clock.ClockTime:t}");
            Console.WriteLine($"AlarmTime={clock.AlarmTime:t}");
            clock.Start();
            Console.WriteLine("Press ENTER to see lambda");
            Console.ReadLine();

            var names = new List<string> {
                "The A-Team",
                "Blade Runner",
                "There's Something About Mary",
                "Batman Begins",
                "The Crow"
            };
            const string Noise = "The ";
            names.Sort((x, y)=>{
                if (x.StartsWith(Noise))
                {
                    x = x.Substring(Noise.Length);
                }
                if (y.StartsWith(Noise))
                {
                    y = y.Substring(Noise.Length);
                }
                return string.Compare(x, y);
            });
            Console.WriteLine("Sorted names:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        static void ClockWakeUp(object sender, EventArgs e)
        {
            Console.WriteLine("Wake up");
        }
        static void ClockTicked(object sender, DateTime e)
        {
            Console.WriteLine($"{e:t}");
        }
    }
}