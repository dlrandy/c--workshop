using System;
using System.Diagnostics;
using System.Linq;


namespace Exer04_11
{

    record Manufacturer(int ManufacturerId, string Name);
    record Car(string Name, int ManufacturerId);

    enum PlayingCardSuit
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds
    }
    record PlayingCard(int Number, PlayingCardSuit Suit)
    {
        public override string ToString()
        {
            return $"{Number} of {Suit}";
        }
    }
    class Deck
    {
        private readonly List<PlayingCard> _cards = new();
        private readonly Random _random = new();
        public Deck()
        {
            for (int i = 1; i <= 10; i++)
            {
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Hearts));
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Clubs));
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Spades));
                _cards.Add(new PlayingCard(i, PlayingCardSuit.Diamonds));
            }
        }
        public PlayingCard Draw()
        {
            var index = _random.Next(_cards.Count);
            var drawnCard = _cards.ElementAt(index);
            _cards.Remove(drawnCard);
            return drawnCard;
        }
    }
    class Program
    {
        public static void Main()
        {
            var processes = Process.GetProcesses().ToList();
            var allProcesses = processes.Count;
            var smallProcesses = processes.Count(proc => proc.PrivateMemorySize64 < 1_000_000);
            var average = processes.Average(p => p.PrivateMemorySize64);
            var max = processes.Max(p => p.PrivateMemorySize64);
            var min = processes.Min(p => p.PrivateMemorySize64);
            var sum = processes.Sum(p => p.PrivateMemorySize64);
            Console.WriteLine("Process Memory Details");
            Console.WriteLine($" All Count: {allProcesses}");
            Console.WriteLine($"Small Count: {smallProcesses}");
            Console.WriteLine($" Average: {FormatBytes(average)}");
            Console.WriteLine($" Maximum: {FormatBytes(max)}");
            Console.WriteLine($" Minimum: {FormatBytes(min)}");
            Console.WriteLine($" Total: {FormatBytes(sum)}");
            var deck = new Deck();
            var hand = new List<PlayingCard>();
            for (int i = 0; i < 3; i++)
            {
                hand.Add(deck.Draw());
            }
            var summary = string.Join(" | ", hand.OrderByDescending(c => c.Number).Select(c => c.ToString()));
            Console.WriteLine($"Hand: {summary}");
            Console.WriteLine($"Any Clubs: {hand.Any(card => card.Suit == PlayingCardSuit.Clubs)}");
            Console.WriteLine($"Any Red: {hand.Any(card => card.Suit == PlayingCardSuit.Hearts || card.Suit == PlayingCardSuit.Diamonds)}");
            Console.WriteLine($"All Diamonds: {hand.All(card => card.Suit == PlayingCardSuit.Diamonds)}");
            Console.WriteLine($"All Even: {hand.All(card => card.Number % 2 == 0)}");
            Console.WriteLine($"Score :{hand.Sum(card => card.Number)}");

            var manufacturers = new List<Manufacturer>{
                new (1, "Ford"),
                new (2, "BMW"),
                new (3, "VM"),
            };
            var cars = new List<Car>{
                new Car("Focus", 1),
                new Car("Galaxy", 1),
                new Car("GT40", 1),
            };

            var joinedQuery = manufacturers.Join(cars,
            manufacturer => manufacturer.ManufacturerId,
            car => car.ManufacturerId,
            (manufacturer, car) => new
            {
                ManufacturerName = manufacturer.Name,
                CarName = car.Name
            }
            );
            foreach (var item in joinedQuery)
            {
                Console.WriteLine($"{item}");
            }
            var query = from manufacturer in manufacturers join car in cars on manufacturer.ManufacturerId equals car.ManufacturerId
                        select new {
                            ManufacturerName = manufacturer.Name, CarName = car.Name
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }

        }
        private static string FormatBytes(double bytes)
        {
            return $"{bytes / Math.Pow(1024, 2):N2} MB";
        }
    }
}

