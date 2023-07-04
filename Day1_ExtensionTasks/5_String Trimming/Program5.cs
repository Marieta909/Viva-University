string sentence = "  Hello, World   ";
string trimmedSen = sentence.Trim();

Console.WriteLine($"Original Text: '{sentence}'");
Console.WriteLine($"Trimmed Text: '{trimmedSen}'");

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

public static class StringExtensions
{
    public static string Trim(this string str)
    {
        //return str.Trim();

        int startIndex = 0;
        int endIndex = str.Length - 1;

        while (startIndex <= endIndex && char.IsWhiteSpace(str[startIndex]))
        {
            startIndex++;
        }

        while (endIndex >= startIndex && char.IsWhiteSpace(str[endIndex]))
        {
            endIndex--;
        }

        return str.Substring(startIndex, endIndex - startIndex + 1);
    }
}