var menuBuilder = new System.Text.StringBuilder();

menuBuilder.AppendLine("Welcome to the burger Joint.");
menuBuilder.AppendLine(string.Empty);
menuBuilder.AppendLine("1) Burgers and Fries - 5 USD");
menuBuilder.AppendLine("2) CheeseBurger - 7 USD");
menuBuilder.AppendLine("3) Double-cheeseBurger - 9 USD");
menuBuilder.AppendLine("4) Coke - 2 USD");
menuBuilder.AppendLine(string.Empty);
menuBuilder.AppendLine("Note  that every burger option comes with fries and ketchup!");

Console.WriteLine(menuBuilder.ToString());

Console.WriteLine("Please type one of the following options to order: ");

var option = Console.ReadKey();

switch (option.KeyChar.ToString())
{
    case "1":
        {
            Console.WriteLine("\n burger on the go!");
            break;
        }
    case "2":
        {
            Console.WriteLine("\n cheeseburger on the go!");
            break;
        }
    case "3":
        {
            Console.WriteLine("\n double cheeeseburger on the go!");
            break;
        }
    case "4":
        {
            Console.WriteLine("\n coke on the go!");
            break;
        }
    default:
        {
            Console.WriteLine("\n invalid option!");
            break;
        }
}

int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++;
}
static bool IsPrime(int number)
{
    if (number == 0 || number == 1)
    {
        return false;
    }
    bool isPrime = true;
    int counter = 2;
    while (counter <= Math.Sqrt(number))
    {
        if (number % counter == 0)
        {
            isPrime = false;
            break;
        }
        counter++;
    }
    return isPrime;
}
static bool IsPrimeWithContinue(int number)
{
    if (number == 0 || number == 1)
    {
        return false;
    }
    bool isPrime = true;
    int counter = 2;
    while (counter <= Math.Sqrt(number))
    {
        if (number % counter != 0)
        {
            counter++;
            continue;
        }
        isPrime = false;
        break;
    }

    return isPrime;
}
static bool IsPrimeWithGoto(int number)
{
    if (number == 0 || number == 1)
    {
        return false;
    }
    bool isPrime = true;
    int counter = 2;
    while (counter <= Math.Sqrt(number))
    {
        if (number % counter == 0)
        {

            isPrime = false;
            goto IsNotPrime;
        }
        counter++;

    }
    IsNotPrime:
    return isPrime;
}
static bool IsPrimeWithReturn(int number)
{
    if (number == 0 || number == 1)
    {
        return false;
    }
   
    int counter = 2;
    while (counter <= Math.Sqrt(number))
    {
        if (number % counter == 0)
        {

            return false;
        }
        counter++;

    }
    
    return true;
}
Console.WriteLine("Enter a number to check whether it is prime: ");
var input = int.Parse(Console.ReadLine() ?? "56");
Console.WriteLine($"{input} is prime? {IsPrimeWithReturn(input)}.");

int t = 0;
do
{
    Console.WriteLine(t);
     t++;
} while (t < 5);

int[] numbers = {1,2,3,4,5};
var nums = new int[5];
var array = new object[5];
array[1] = "Hello";



