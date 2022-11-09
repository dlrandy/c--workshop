var numberToBeGuessed = new Random().Next(0, 10);
var remainingChances = 5;
var numberFound = false;

Console.WriteLine("Welcome to Guessing Game.");

while (remainingChances > 0 && !numberFound)
{
    Console.WriteLine($"\n You have {remainingChances} chances. Please type a number between 0 and 10 to try to guess the number generated for you.");
    var num = int.Parse(Console.ReadLine());
    if (num == numberToBeGuessed)
    {
        numberFound = true;
    }
    else
    {
        remainingChances--;
    }
}

if (numberFound)
{
    Console.WriteLine($"congrats!You've guessed the number correctlly with {remainingChances} chances left.");

}
else
{
    Console.WriteLine($"You're out of chances. The number was {numberToBeGuessed}.");
}