class BadFile
{
    public string Read(string filePath){
        return "";
    }
    public void Write(string filePath, string content){

    }
}

public interface IWriter {
    void Write(string filePath, string content);
}
public interface IReader
{
    string Read(string filePath);
}
public class Reader:IReader
{
    public string Read(string filePath){
        return "";
    }
}
public class Writer:IWriter
{
    public void Write(string filePath, string content){

    }
}

public class GoodFile
{
    private readonly Reader _reader;
    private readonly Writer _writer;
    public GoodFile(){
        _reader = new Reader();
        _writer = new Writer();
    }

    public string Read(string filePath)=>_reader.Read(filePath);

    public void Write(string filePath, string content) => _writer.Write(filePath, content);

}

public class BetterFile
{
     private readonly Reader _reader;
    private readonly Writer _writer;
    public BetterFile(Reader reader, Writer writer){
        _reader = reader;
        _writer = writer;
    }

    public virtual string Read(string filePath)=>_reader.Read(filePath);

    public virtual void Write(string filePath, string content) => _writer.Write(filePath, content);

}


public class BestFile
{
     private readonly IReader _reader;
    private readonly IWriter _writer;
    public BestFile(IReader reader, IWriter writer){
        _reader = reader;
        _writer = writer;
    }

    public virtual string Read(string filePath)=>_reader.Read(filePath);

    public virtual void Write(string filePath, string content) => _writer.Write(filePath, content);

}

public class Merchandise
{
    public string Name {get;set;}
    public decimal Price {get;set;}
    public decimal Vat {get;set;}
    public Merchandise(string name, decimal price, decimal vat){
        Name = name;
        Price = price;
        Vat = vat;
    }
    public decimal NetPrice => Price * (1 + Vat / 100);
}

public static class TaxCalculator
{
    public static decimal CalculateNetPrice(decimal price, decimal vat){
        return price * (1 + vat /  100);
    }
    public static void Main(){}
}


class Car
{
    public object Body {get;set;}
    public Car(object body){
        Body = body;
    }
    public virtual void Move(){

    }
}

class CarWreck:Car{

CarWreck(object body):base(body){}
public override void Move(){
    throw new NotSupportedException("A broken car cannot start....");
}
    
}

class CarWreck2
{
     public object Body {get;set;}
      public CarWreck2(object body){
        Body = body;
    }
}


public class Location
{
    
}
interface IMovableDamageable
{
    void Move(Location lcoation);
    float Hp{get;set;}
}

class ScoreText:IMovableDamageable
{
    public float Hp {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }
    public void Move(Location location){
        Console.WriteLine($"Moving to {location}");
    }
}


interface IMovable
{
    void Move(Location location);

}
interface IDamageable{
    float Hp{get;set;}
}


class House1 : IDamageable
{
    public float Hp { get; set; }
}
class ScoreText1 : IMovable
{
 public void Move(Location location)
 {
 Console.WriteLine($"Moving to {location}");
 }
}



public class Dog
{
    public string Name{get;}
    public Dog(string name){
        Name = name;
    }
}

public static class DogGenerator
{
    private static int Counter {get;  set;}
    static DogGenerator(){
        Counter = 0;
    }
    public static Dog GenerateDog(){
        Counter+=1;
        return new Dog("Dog " + Counter);
    }
}















