var aGolden = new GoldenRetriever(){Name="Aspen"};
var anotherGolden = new GoldenRetriever(){Name="Aspen"};

var aBorder = new BorderCollie(){Name ="Apsen"};
var anotherBorder = new BorderCollie(){Name ="Apsen"};

var aBernese = new Bernese(){Name="Aspen"};
var anotherBernese = new Bernese(){Name="Aspen"};

var goldenComparison = aGolden.Equals(anotherGolden)?"these golden retrivers have the same name":
"these goldens have different names";
var borderComparison = aBorder.Equals(anotherBorder)?"these Border Collies have the same name":
"these borders have different names";
var berneseComparison = aBernese.Equals(anotherBernese)?"these Berneses have the same name":
"these Berneses have different names";

Console.WriteLine(goldenComparison);
Console.WriteLine(borderComparison);
Console.WriteLine(berneseComparison);

int a = default;
int b = default;
Console.WriteLine(a == b);
// var c = default;
// var d = default;
// Console.WriteLine(c == d);
struct GoldenRetriever
{
    public string? Name {get; set;}
}
class BorderCollie
{
    public string? Name {get; set;}
}
class Bernese{
    public string? Name {get;set;}
    public override bool Equals(object? obj)
    {
        if (obj is Bernese borderCollie && obj != null)
        {
           return this.Name == borderCollie.Name;  
        }
        return false;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}