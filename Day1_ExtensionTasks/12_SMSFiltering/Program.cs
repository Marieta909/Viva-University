using System.Text;

Console.OutputEncoding = Encoding.Unicode;

List<SMS> smsMessages = new()
{
    new SMS { Sender = "Viva-MTS", Content = "+20ԳԲ․ ավելացրու քո սակագնային պլանի հիմնական ինտերնետ փաթեթը ևս 20ԳԲ-ով։" },
    new SMS { Sender = "Ucom", Content = "Սակագնային պլանի փաթեթները վերաակտիվացվել են։" },
    new SMS { Sender = "Viva-MTS", Content = "Ձեր հաշիվը վերալիցքավորվել է 2000 դրամով։" }
};

string sender = "Viva-MTS";
var filteredMessages = smsMessages.FilterBySender(sender).FilterByKeyword("փաթեթը");

foreach (SMS sms in filteredMessages)
{
    Console.WriteLine($"Sender: {sms.Sender}, Content: {sms.Content}");
}


public static class EnumerableExtensions
{
    public static IEnumerable<SMS> FilterBySender(this IEnumerable<SMS> smsMessages, string sender)
    {
        return smsMessages.Where(sms => sms.Sender == sender);
    }

    public static IEnumerable<SMS> FilterByKeyword(this IEnumerable<SMS> smsMessages, string keyword)
    {
        return smsMessages.Where(sms => sms.Content.Contains(keyword));
    }
}
public class SMS
{
    public string? Sender { get; set; }
    public string? Content { get; set; }
}