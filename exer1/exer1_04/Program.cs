Console.WriteLine("Type a value for a:");
var a = int.Parse(Console.ReadLine());
Console.WriteLine("Now type a value for b:");
var b = int.Parse(Console.ReadLine());

Console.WriteLine($"the value for a is {a} and for b is {b}");
Console.WriteLine($"Sum: {a + b}");
Console.WriteLine($"Mulplication: {a * b}");
Console.WriteLine($"Subtraction: {a - b}");
Console.WriteLine($"SDivision: {a / b}");

var person1 = new Person();
person1.Name = "john";
person1.Age = 23;

var person2 = new Person(){Name="john", Age=23};
var person3 =  new Person("john", 23);

var now = DateTime.Now;
var utcNow = DateTime.UtcNow;
Console.WriteLine(now);
Console.WriteLine(utcNow);
public class Person
{
    public string Name {get; set;}
    public int Age {get; set;}
    public Person(){}
    public Person(string name, int age){
        Name = name;
        Age = age;
    }
    public void GetInfo(){
        Console.WriteLine($"Name: {Name} - IsChild ? {IsChild()}");
    }
    public bool IsChild(){
        return Age < 12;
    }
}


