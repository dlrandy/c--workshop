public interface IWorker
{
    void Work();
}

public class Ant:IWorker
{
    public void Work(){
        Console.WriteLine("Ant is working hard.");
    }
}

public class Robot:IWorker
{
    public void Work(){
        Console.WriteLine("Beep boop - I amn");
    }
}


public interface IFlyer
{
    void Fly();
}

public class Drone : IFlyer, IWorker
{
    public void Fly(){
        Console.WriteLine("Flying");
    }
 public void Work(){
        Console.WriteLine("Working");
    }
}

public interface IDrone : IWorker, IFlyer
{
    
}


public interface IIDentifiable
{
    long Id {get;}
}





















