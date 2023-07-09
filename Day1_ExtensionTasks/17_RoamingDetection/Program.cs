List<CallRecord> callRecords = new()
{
    new CallRecord { PhoneNumber = "123456789", MCC = "283", MNC = "05", CallDuration = TimeSpan.FromMinutes(5) },
    new CallRecord { PhoneNumber = "987654321", MCC = "284", MNC = "01", CallDuration = TimeSpan.FromMinutes(8) },
    new CallRecord { PhoneNumber = "654321987", MCC = "283", MNC = "05", CallDuration = TimeSpan.FromMinutes(7) },
    new CallRecord { PhoneNumber = "789456123", MCC = "283", MNC = "02", CallDuration = TimeSpan.FromMinutes(3) }
};

IEnumerable<CallRecord> roamingCalls = callRecords.DetectRoamingCalls();

Console.WriteLine("Roaming Calls:");
foreach (var call in roamingCalls)
{
    Console.WriteLine($"Phone Number: {call.PhoneNumber}, MCC: {call.MCC}, MNC: {call.MNC}, Call Duration: {call.CallDuration}");
}


public static class EnumerableExtensions
{
    public static IEnumerable<CallRecord> DetectRoamingCalls(this IEnumerable<CallRecord> callRecords)
    {
        return callRecords.Where(record => record.MCC != "283" || record.MNC != "05");
    }
}

public class CallRecord
{
    public string? PhoneNumber { get; set; }
    public string MCC { get; set; }
    public string MNC { get; set; }
    public TimeSpan CallDuration { get; set; }
}