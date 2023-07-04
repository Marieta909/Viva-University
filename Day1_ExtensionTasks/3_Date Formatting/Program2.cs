DateTime dateTime = DateTime.Now;

string userFriendlyString = dateTime.ToUserFriendlyString();
Console.WriteLine(userFriendlyString);

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
public static class DateTimeExtensions
{
    public static string ToUserFriendlyString(this DateTime dateTime)
    {
        {
            return dateTime.ToString("MMMM d, yyyy");
        }
    }
}
