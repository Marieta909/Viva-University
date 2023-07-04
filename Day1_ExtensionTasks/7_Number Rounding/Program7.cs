double number = 3.14159;
int decimalPlaces = 2;

double roundedNumber = number.Round(decimalPlaces);

Console.WriteLine($"Given Number: {number}");
Console.WriteLine($"Rounded Number: {roundedNumber}");

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

public static class DoubleExtensions
{
    public static double Round(this double value, int decimalPlaces)
    {   
        return Math.Round(value * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
    }
}

