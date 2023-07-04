string filePath = @"C:\temp\file.txt";

bool exists = filePath.FileExists();

Console.WriteLine(exists);

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

public static class StringExtensions
{
    public static bool FileExists(this string filePath)
    {
        return File.Exists(filePath);
    }
}
