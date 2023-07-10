////----------------Task 1 - DateTime

//string input = "Dzer sakagnayin planum nerarvats patetnery veraaktivacel en yev gortsum en minchev @expDate@. Patetneri mnacordy stugelu hamar ugharkeq *208#.";

//string result = ReplaceExpDateParameter(input);
//Console.WriteLine(result);

//static string ReplaceExpDateParameter(string input)
//{
//    DateTime expDate = DateTime.Now.AddDays(30);
//    string formattedExpDate = expDate.ToString("dd/MM/yyyy HH:mm");

//    string result = input.Replace("@expDate@", formattedExpDate);
//    return result;
//}

////-------------------------Task 2 - DateTime

//string input = "Dzer sakagnayin planum nerarvats patetnery veraaktivacel en yev gortsum en minchev @expDate@. Patetneri mnacordy stugelu hamar ugharkeq *209#.";

//string result = ReplaceExpDateParameter(input);
//Console.WriteLine(result);

//static string ReplaceExpDateParameter(string input)
//{
//    DateTime lastDayOfMonth = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day).AddMilliseconds(-1);
//    string formattedExpDate = lastDayOfMonth.ToString("dd/MM/yyyy HH:mm:ss.fff");

//    string result = input.Replace("@expDate@", formattedExpDate);
//    return result;
//}

////---------------------Task 3 - DateTime

//DateTime date1 = new(2023, 7, 1);
//DateTime date2 = new(2023, 7, 10);

//int elapsedDays = CalculateElapsedDays(date1, date2);

//Console.WriteLine("Elapsed Days: " + elapsedDays);


//static int CalculateElapsedDays(DateTime date1, DateTime date2)
//{
//    TimeSpan elapsedDays = date2 - date1;

//    return (int)elapsedDays.TotalDays;
//}

////-------------------Task 4 - DateTime
//using System.Globalization;

//Console.OutputEncoding = System.Text.Encoding.UTF8;

//DateTime date = DateTime.Now;
//string weekdayName = date.GetWeekdayName("german");
//Console.WriteLine("Weekday Name: " + weekdayName);

//public static class DateTimeExtensions
//{
//    public static string GetWeekdayName(this DateTime date, string language)
//    {
//        CultureInfo cultureInfo = GetCultureInfoByLanguage(language);
//        return date.ToString("dddd", cultureInfo);
//    }

//    private static CultureInfo GetCultureInfoByLanguage(string language)
//    {
//        switch (language.ToLower())
//        {
//            case "armenian":
//                return new CultureInfo("hy-AM");
//            case "english":
//                return new CultureInfo("en-US");
//            case "russian":
//                return new CultureInfo("ru-RU");
//            default:
//                throw new ArgumentException("Unsupported language.");
//        }
//    }
//}

//--------------------Task 5 - String splitting

string ussdCommand = "*208*2000*1#";
Ussd ussd = ParseUssdCommand(ussdCommand);

Console.WriteLine($"USSD Code: {ussd.Code}" );
Console.WriteLine($"USSD Actions: {{{string.Join(", ", ussd.Actions)}}}");


static Ussd ParseUssdCommand(string ussdCommand)
{
    ussdCommand = ussdCommand.TrimStart('*').TrimEnd('#');

    string[] parts = ussdCommand.Split('*');

    int code = int.Parse(parts[0]);
    int[] actions = parts.Skip(1).Select(int.Parse).ToArray();

    return new Ussd
    {
        Code = code,
        Actions = actions
    };
}

class Ussd
{
    public int Code { get; set; }
    public int[]? Actions { get; set; }
}


