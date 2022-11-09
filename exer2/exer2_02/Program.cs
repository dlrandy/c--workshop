public class Rectangle
{
    private readonly double _width;
    private readonly double _height;

    public double Area{
        get{
            return _width * _height;
        }
    }
    public Rectangle(double width, double height){
        _width = width;
        _height = height;
    }
}
public class Circle
{
    private readonly double _radius;
     

    public double Area{
        get{
            return Math.PI * _radius * _radius;
        }
    }
    public Circle(double radius){
       _radius = radius;
    }
}

public static class Solution
{
    public const string Equal = "equals";
    public const string Rectanglar = "rectanglar";
    public const string Circular = "circular";
    public static string Solve(Rectangle[] rectanglarSection, Circle[] circularSection){
        var totalAreaOfRectangles = CalculateTotalAreaOfRectangles(rectanglarSection);
        var totalAreaOfCircles = CalculateTotalAreaOfCircles(circularSection);
        return GetBigger(totalAreaOfCircles, totalAreaOfRectangles);
    }
    private static double CalculateTotalAreaOfRectangles(Rectangle[] rectangularSection){
        double totalAreaOfRectangles = 0;
        foreach (var rectangle in rectangularSection)
        {
            totalAreaOfRectangles += rectangle.Area;
        }
        return totalAreaOfRectangles;
    }
    private static double CalculateTotalAreaOfCircles(Circle[] circularSection){
        double totalAreaOfCircles = 0;
        foreach (var circle in circularSection)
        {
            totalAreaOfCircles += circle.Area;
        }
        return totalAreaOfCircles;
    }
    private static string GetBigger(double totalAreaOfRectangles, double totalAreaOfCircles){
        const double margin = 0.01;
        bool areaAlmostEqual = Math.Abs(totalAreaOfCircles - totalAreaOfRectangles) <= margin;
        if (areaAlmostEqual)
        {
            return Equal;
        } else if (totalAreaOfRectangles > totalAreaOfCircles)
        {
            return Rectanglar;
        } else {
            return Circular;
        }
    }
    public static void Main(){
        string compare1 = Solve(new Rectangle[0], new Circle[0]);
        string compare2 = Solve(new[] {new Rectangle(1,5)}, new Circle[0]);
        string compare3 = Solve(new Rectangle[0], new[]{new Circle(1)});
        string compare4 = Solve(new[] {new Rectangle(3,4), new Rectangle(5,6)}, new []{new Circle(1), new Circle(10)});

        Console.WriteLine($"compare1 is {compare1}, " + 
        $"compare2 is {compare2}, " + 
        $"compare3 is {compare3}, " + 
        $"compare4 is {compare4} "+
        $"0 is {(new Rectangle[0,1])}"
        );
    }
}

public class LoginService
{
    private string[]  _userNames;
    private string[] _passwords;


    public bool Login(string username, string passsword){
        bool isLoggedIn = true;
        return isLoggedIn;
    }
}
public class Human
{
    public string Name {get;}
    public int Age {get;}
    public float Weight {get;}
    public float Height {get;}

    public Human(string name, int age, float weight, float height){
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
    }
}

public class MailMan : Human{
public MailMan(string name, int age, float weight, float height):base(name, age, weight, height){}
public void DeliverMail(MailMan mail){}
}
 
 public class Mail
{
 public string Message { get; }
 public string Address { get; }
 public Mail(string message, string address)
 {
 Message = message;
 Address = address;
 }
}
