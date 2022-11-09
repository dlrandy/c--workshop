Console.WriteLine("Are the local and utc dates equal? {0}", DateTime.Now.Date == DateTime.UtcNow.Date);

Console.WriteLine("\nIf the dates are equal, does it mean that there's no Timespan interval between them? {0}",
(DateTime.Now.Date - DateTime.UtcNow.Date) == TimeSpan.Zero
);

Console.WriteLine((DateTime.Now.Date - DateTime.UtcNow.Date));

DateTime localTime = DateTime.Now;
DateTime utcTime = DateTime.UtcNow;
TimeSpan interval = (localTime - utcTime);

Console.WriteLine("\nDiference between the {0} time and {1} time:{2}:{3} hours",
localTime.Kind.ToString(),
utcTime.Kind.ToString(),
interval.Hours,
interval.Minutes
);

Console.Write("\nIf we jump two days to the future on {0} we'll be on{1}\n",
new DateTime(2022, 10, 23).ToShortDateString(),
new DateTime(2022, 10, 23).AddDays(2).ToShortDateString()
);

var frenchDate = new DateTime(2008, 3, 1, 7, 0,0);
Console.WriteLine(frenchDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")));
Console.WriteLine(frenchDate.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
Console.WriteLine(frenchDate.ToString("yyyyMMddTHH:mm:ss"));
