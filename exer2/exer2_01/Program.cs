public class Book
{
    public string Title = "";
    public string Author = "";
    public string Publisher = "";
    public int Pages;
    public string Description = "";
}

public static class Solution
{
    public static void Main()
    {
        Dog dog = new Dog("Ricky");
        dog.Owner = "Tobias";

        Dog dog2 = new Dog("riocky"){
            Owner = "Tobias",
        };

        Dog[] dogs = new Dog[2];
        dogs[0] = dog;
        dogs[1] = dog2;

        Dog[] dogs1 = {dog, dog2};

        // Book book1 = new Book();
        // book1.Author = "New Writer";
        // book1.Title = "First Book";
        // book1.Publisher = "Publisher 1";
        // Book book2 = new Book();
        // book2.Author = "New Writer";
        // book2.Title = "Second Book";
        // book2.Publisher = "Publisher 2";
        // book2.Description = "Interesting read";
        // Print(book1);
        // Print(book2);
    }
    private static void Print(Book book)
    {
        Console.WriteLine($"Author: {book.Author}," +
        $"Title: {book.Title}, " +
        $"Publisher: {book.Publisher}, " +
        $"Description: {book.Description}. "
        );
    }

    public static void ResetOwner(Dog dog)
    {
        dog.Owner = "None";
    }
    private static void Recreate(Dog dog)
    {
        dog = new Dog("Recreated ");
    }
}
public class Dog
{
    public Dog(string name){
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("name");
        }
        Name = name;
        Owner = "sdfsdf";
    }
    public string Owner = "";
    public string Name{set;get;}
    // public string Name1{get; private set;}
    // public string Name2 {get;} = "unnamed";
    // private string _Name3;
    // public string Name3{
    //     get{
    //         return "dog's name is " + _Name3;
    //     }
    // }
    // private string _name4;
    // public string Name4 => "Dog's name is " + _name4;
    // private string _owner;
    // public string Owner1{
    //     get{
    //         return _owner;
    //     }
    //     set{
    //         _owner = value;
    //     }
    // }
}

