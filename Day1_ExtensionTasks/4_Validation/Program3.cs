using System.Text.RegularExpressions;

string email1 = "example@example.com";
string email2 = "invalid_email";
string email3 = "";

bool isValid1 = email1.IsValidEmail();
bool isValid2 = email2.IsValidEmail();
bool isValid3 = email3.IsValidEmail();

Console.WriteLine($"Email 1: {email1}, Valid: {isValid1}");
Console.WriteLine($"Email 2: {email2}, Valid: {isValid2}");
Console.WriteLine($"Email 3: {email3}, Valid: {isValid3}");

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

public static class StringExtensions
{
    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}