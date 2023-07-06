public class Program
{
    public static void Main(string[] args)
    {
        List<Person> personList = new List<Person>
        {
            new Person { Name = "Ani", Age = 20 },
            new Person { Name = "Aleqs", Age = 25 },
            new Person { Name = "Mane", Age = 14 },
            new Person { Name = "Serj", Age = 20 }
        };

        List<Person> sortedList = personList.SortByProperty(p => p.Age);

        foreach (Person person in sortedList)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}

public static class ListExtensions
{
    public static List<T> SortByProperty<T, TKey>(this List<T> list, Func<T, TKey> keySelector)
    {
        return list.OrderByDescending(keySelector).ToList();
    }
}

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
}


