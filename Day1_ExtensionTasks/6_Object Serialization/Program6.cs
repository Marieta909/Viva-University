using System.Text.Json;

var myObject = new Person
{
    Name = "Marieta Meloyan",
    Age = 21,
    Email = "marieta@example.com"
};

var json = myObject.ToJson();
Console.WriteLine(json);

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

public static class ObjectExtensions
{
    public static string ToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}

class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }
}