List<DataUsage> dataUsageRecords = new()
{
    new DataUsage { Date = new DateTime(2023, 1, 1), UsageInBytes = 100 },
    new DataUsage { Date = new DateTime(2023, 1, 2), UsageInBytes = 200 },
    new DataUsage { Date = new DateTime(2023, 1, 3), UsageInBytes = 150 },
    new DataUsage { Date = new DateTime(2023, 1, 4), UsageInBytes = 300 }
};

DateTime startDate = new (2023, 1, 2);
DateTime endDate = new (2023, 1, 4);

long totalUsage = dataUsageRecords.CalculateTotalUsage(startDate, endDate);

Console.WriteLine($"Total Data Usage: {totalUsage} bytes");



public static class EnumerableExtensions
{
    public static long CalculateTotalUsage(this IEnumerable<DataUsage> dataUsageRecords, DateTime startDate, DateTime endDate)
    {
        return dataUsageRecords
            .Where(usage => usage.Date >= startDate && usage.Date <= endDate)
            .Sum(usage => usage.UsageInBytes);
    }
}

public class DataUsage
{
    public DateTime Date { get; set; }
    public long UsageInBytes { get; set; }
}