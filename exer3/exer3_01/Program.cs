User FindBySurname(string name)
{
    foreach (var user in _users)
    {
        if (user.Surname == name)
        {
            return user;
        }
    }
    return null;
}
User FindByLoginName(string name)
{
    foreach (var user in _users)
    {
        if (user.LoginName == name)
        {
            return user;
        }
    }
    return null;
}
User FindByLocation(string location)
{
    foreach (var user in _users)
    {
        if (user.Location == location)
        {
            return user;
        }
    }
    return null;
}
void DoSearch()
{
    var user1 = FindBySurname("Wright");
    var user2 = FindByLoginName("JamesR");
    var user3 = FindByLocation("Scotland");
    var user4 = Find(user => user.Surname == "Wright");
    var user5 = Find(user => user.LoginName == "JamesR");
    var user6 = Find(user => user.Location == "Scotland");
}

User Find(FindUser predicate)
{
    foreach (var user in _users)
    {
        if (predicate(user))
        {
            return user;
        }
    }
    return null;
}

void Transform()
{
    var rotatePoint1 = Calculate(Rotate, 100, 20);
    var zoomPoint1 = Calculate(Zoom, 5, 5);
}

Point Calculate(TransformPoint transformer, double height, double width)
{
    var point = transformer(height, width);
    // do stuff to point
    return point;
}
Point Rotate(double height, double width)
{
    return new Point();
}
Point Zoom(double height, double width)
{
    return new Point();
}

delegate Point TransformPoint(double height, double width);


public class Transformer
{
    public void Transform()
    {
        var rotataPoint = Calculate(new RotateTransform(), 200, 20);
        var zoomPoint = Calculate(new ZoomTransform(), 4, 5);
    }
    private Point Calculate(ITransform transformer, double height, double width)
    {
        var point = transformer.Move(height, width);
        // so stuff to point
        return point;
    }
}



public class RotateTransform : ITransform
{
    public Point Move(double height, double width)
    {
        // so stuff
        return new Point();
    }
}

public class ZoomTransform : ITransform
{
    public Point Move(double height, double width)
    {
        // so stuff
        return new Point();
    }
}




public class Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

public interface ITransform
{
    Point Move(double hieght, double width);
}



delegate bool FindUser(User user);

class User
{

}
