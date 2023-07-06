string colorString = "Red";

Color color = colorString.ToEnum<Color>();

Console.WriteLine(color);

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
public static class StringExtensions
{
    public static TEnum ToEnum<TEnum>(this string value) where TEnum : Enum
    {
        return (TEnum)Enum.Parse(typeof(TEnum), value, true);
    }
}
enum Color
{
    Red,
    Green,
    Blue
    
}