public interface IShape
{
    double Area { get; }

}

public class Rectangle : IShape
{
    private readonly double _width;
    private readonly double _height;

    public double Area
    {
        get
        {
            return _width * _height;
        }
    }
    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }
}
public class Circle : IShape
{
    private readonly double _radius;
    public Circle(double radius)
    {
        _radius = radius;
    }
    public double Area
    {
        get
        {
            return Math.PI * _radius * _radius;
        }
    }

}

public class Program
{
    public static bool IsEnough(double mosaicArea, IShape[] tiles)
    {
        double totalArea = 0;
        foreach (var tile in tiles)
        {
            totalArea += tile.Area;
        }
        const double tolerance = 0.0001f;
        return totalArea - mosaicArea >= -tolerance;
    }
    public static void Main()
    {
        var isEnough1 = IsEnough(0, new IShape[0]);
        var isEnough2 = IsEnough(1, new[] { new Rectangle(1, 1) });
        var isEnough3 = IsEnough(100, new IShape[] { new Circle(5) });
        var isEnough4 = IsEnough(5, new IShape[]
        {
new Rectangle(1, 1), new Circle(1), new Rectangle(1.4,1)
        });
        Console.WriteLine($"IsEnough1 = {isEnough1}, " +
        $"IsEnough2 = {isEnough2}, " +
       $"IsEnough3 = {isEnough3}, " +
       $"IsEnough4 = {isEnough4}.");
    }
}



















