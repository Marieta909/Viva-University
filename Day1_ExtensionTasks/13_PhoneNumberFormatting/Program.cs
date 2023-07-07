string phoneNumber = "37494600445";
string phoneNumber1 = "3749070113";
string formattedNumber = phoneNumber.FormatPhoneNumber();
string formattedNumber1 = phoneNumber1.FormatPhoneNumber();

Console.WriteLine(formattedNumber);
Console.WriteLine(formattedNumber1);
public static class StringExtensions
{
    public static string FormatPhoneNumber(this string phoneNumber)
    {
        string digitsOnly = new(phoneNumber.Where(char.IsDigit).ToArray());

        if (digitsOnly.Length != 11)
        {
            return phoneNumber;
        }

        return $"(+{digitsOnly[..3]})-{digitsOnly.Substring(3, 2)}-{digitsOnly.Substring(5, 3)}-{digitsOnly[8..]}";

        //or
        //return long.Parse(digitsOnly).ToString("+(###)-##-###-###");
    }
}
