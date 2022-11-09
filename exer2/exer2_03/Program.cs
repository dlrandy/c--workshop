// class Tile
// {

// }
// class MovingTile:Tile
// {
//     public void Move(){}
// }

// class TrapTile : Tile
// {
//     public void Damage(){}
// }

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
class Tile
{

}
class Motor
{
    public void Move() { }
}
class Trap
{
    public void Damage() { }
}
class MovingTile : Tile
{
    private readonly Motor _motor;
    public MovingTile(Motor motor)
    {
        _motor = motor;
    }
    public void Move()
    {
        _motor.Move();
    }
}

class TrapTile : Tile
{
    private readonly Trap _trap;
    public TrapTile(Trap trap)
    {
        _trap = trap;
    }
    public void Damage()
    {
        _trap.Damage();
    }
}

class MovingTrapTile : Tile
{
    private readonly Motor _motor;
    private readonly Trap _trap;
    public MovingTrapTile(Motor motor, Trap trap)
    {
        _motor = motor;
        _trap = trap;
    }
    public void Move()
    {
        _motor.Move();
    }
    public void Damage()
    {
        _trap.Damage();
    }
}


public abstract class Human
{
    public string Name { get; }
    public int Age { get; }
    public float Weight { get; }
    public float Height { get; }

    protected Human(string name, int age, float weight, float height)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
    }
    public abstract void Work();
    public override string ToString()
    {
        return $"{nameof(Name)}:{Name}, " +
        $"{nameof(Age)}: {Age}," +
        $"{nameof(Weight)}: {Weight}," +
        $"{nameof(Height)}: {Height}";
    }
}

public class MailMan : Human
{
    public MailMan(string name, int age, float weight, float height) : base(name, age, weight, height)
    {

    }
    public void DeliverMail(Mail mail)
    {

    }

    public override void Work()
    {
        Console.WriteLine("A mailman us delivering mails.");
    }
}

public class Teacher : Human
{
    public Teacher(string name, int age, float weight, float height) : base(name, age, weight, height)
    {

    }
    public override void Work()
    {
        Console.WriteLine("A teacher is teaching.");
    }
}

class Person
{
    public void Say()
    {
        Console.WriteLine("hello");
    }
    public void Say(string words)
    {
        Console.WriteLine(words);
    }
}

public class Program
{
    public static void Main()
    {
        MailMan mailman = new MailMan("sss", 34, 23f, 22f);
        Teacher teacher = new Teacher("xxx", 23, 4f, 6f);
        Human[] humans = { mailman, teacher };
        foreach (var human in humans)
        {
            human.Work();
            Console.WriteLine(human);
        }

    }
}

public class ProgressBar
{
    private const float Tolerance = 0.001f;
    private float _current;
    public float Current {
        get => _current;
        set{
            if (value >= Max)
            {
                _current = Max;
            } else if (value < 0)
            {
                _current = 0;
            } else {
                _current = value;
            }
        }
    }
    public float Max {get;}

    public bool IsComplete => Math.Abs(Max - _current) < Tolerance;
    public ProgressBar(float current, float max){
        Max = max;
        Current = current;
      
    }
}