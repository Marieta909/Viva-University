List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };
bool condition = true;

List<int> filteredList = numbers.WhereIf(condition, n => n % 2 == 0).ToList();

foreach (int number in filteredList)
{
    Console.WriteLine(number);
}


public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
    {
        return condition ? source.Where(predicate) : source;
    }
}