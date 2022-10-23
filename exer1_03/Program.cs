static void FormatString(string stringToFormat){
    stringToFormat.Replace("World", "Mars");
}

static string FormatReturningString(string stringToFormat){
    return stringToFormat.Replace("Earth", "Mars");
}

var greetings = "Hello World!";
FormatString(greetings);

Console.WriteLine(greetings);
var anotherGreetings = "Good morning Earth!";
Console.WriteLine(FormatReturningString(anotherGreetings));

string first = "Hello.";
string second = first;
first = null;
Console.WriteLine(first == second);
Console.WriteLine(string.Equals(first, second));