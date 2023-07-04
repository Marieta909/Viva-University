string str = "hello world";
string titleCase = str.TitleCase();
Console.WriteLine(titleCase);

public static class StringExtensions
{
    public static string TitleCase(this string titleCase)
    {
        string[] words = titleCase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                char firstLetter = char.ToUpper(words[i][0]);
                string rest = words[i][1..].ToLower();
                words[i] = firstLetter + rest;
            }
        }
        return string.Join(" ", words);
    }
}