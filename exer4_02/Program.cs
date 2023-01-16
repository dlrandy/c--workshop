using System;
using System.Collections.Generic;

namespace Exer04_02
{
    class QueueExample
    {
        record CustomerOrder(string Name, int TicketRequested) { }
        public static void Main()
        {
            var ticketsAvailable = 10;
            var customers = new Queue<CustomerOrder>();
            customers.Enqueue(new CustomerOrder("Dave", 2));
            customers.Enqueue(new CustomerOrder("Siva", 4));
            customers.Enqueue(new CustomerOrder("Julien", 3));
            customers.Enqueue(new CustomerOrder("Kane", 2));
            customers.Enqueue(new CustomerOrder("Ann", 1));


            while (customers.TryDequeue(out CustomerOrder nextOrder))
            {
                if (nextOrder.TicketRequested <= ticketsAvailable)
                {
                    ticketsAvailable -= nextOrder.TicketRequested;
                    Console.WriteLine($"Congratulations {nextOrder.Name}, you've purchased {nextOrder.TicketRequested} tickets");
                } else {
                    Console.WriteLine($"Sorry {nextOrder.Name}, cannot fulfil {nextOrder.TicketRequested} tickets");
                }
            }
            Console.WriteLine($"Finished. Available={ticketsAvailable}");
            Console.ReadLine();

        }
    }
}