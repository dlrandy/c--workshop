using System;
using System.Collections;
using System.Collections.Generic;

namespace Exer04_01
{
    public class Tab
    {
        public Tab() { }


        public Tab(string url) => Url = url;

        public string Url { get; set; }
        public override string ToString()
        {
            return Url;
        }

    }
    public class TabController : IEnumerable<Tab>
    {
        private readonly List<Tab> _tabs = new();

        public Tab OpenNew(string url)
        {
            var tab = new Tab(url);
            _tabs.Add(tab);
            Console.WriteLine($"OpenNew {tab}");
            return tab;
        }
        public void Close(Tab tab)
        {
            if (_tabs.Remove(tab))
            {
                Console.WriteLine($"Removed {tab}");
            }
        }
        public void MoveToStart(Tab tab)
        {
            if (_tabs.Remove(tab))
            {
                _tabs.Insert(0, tab);
                Console.WriteLine($"Moved {tab} to start");
            }
        }

        public void MoveToEnd(Tab tab)
        {
            if (_tabs.Remove(tab))
            {
                _tabs.Add(tab);
                Console.WriteLine($"Moved {tab} to end. Index={_tabs.IndexOf(tab)}");
            }
        }

        public IEnumerator<Tab> GetEnumerator() => _tabs.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _tabs.GetEnumerator();


    }

     static class Program
        {
            public static void Main()
            {
                var controller = new TabController();
                Console.WriteLine("Opening tabs...");
                var packet = controller.OpenNew("packetpub.com");
                var msoft = controller.OpenNew("microsoft.com");
                var amazon = controller.OpenNew("amazon.com");

                controller.LogTabs();
                Console.WriteLine("Moving...");
                controller.MoveToStart(amazon);
                controller.MoveToEnd(packet);
                controller.LogTabs();

                Console.WriteLine("Closing tab...");
                controller.Close(msoft);
                controller.LogTabs();
            }

            private static void LogTabs(this IEnumerable<Tab> tabs)
            {
                Console.Write("TABS: |");
                foreach (var tab in tabs)
                {
                    Console.Write($"{tab.Url.PadRight(15)}|");
                }
                Console.WriteLine();
            }


        }

}