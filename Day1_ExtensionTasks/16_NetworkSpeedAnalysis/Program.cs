List<NetworkSpeed> networkSpeedRecords = new()
{
    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 0, 0), SpeedInMbps = 50.0 },
    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 5, 0) },
    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 10, 0), SpeedInMbps = 70.0 },
    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 15, 0) },
    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 25, 0), SpeedInMbps = 75.0 }
};

DateTime startDate = new(2023, 1, 1, 10, 0, 0);
DateTime endDate = new(2023, 1, 1, 10, 20, 0);

double averageSpeed = networkSpeedRecords.CalculateAverageSpeed(startDate, endDate);

Console.WriteLine($"Average Speed: {averageSpeed} Mbps");

public static class EnumerableExtensions
{
    public static double CalculateAverageSpeed(this IEnumerable<NetworkSpeed> networkSpeedRecords, DateTime startDate, DateTime endDate)
    {
        var filteredRecords = networkSpeedRecords
            .Where(record => record.TimeStamp >= startDate && record.TimeStamp <= endDate && record.SpeedInMbps.HasValue)
            .ToList();

        if (filteredRecords.Count == 0)
            return 0.0;

        double totalSpeed = filteredRecords.Sum(record => record.SpeedInMbps.Value);
        double averageSpeed = totalSpeed / filteredRecords.Count;
        return averageSpeed;
    }
}


public class NetworkSpeed
{
    public DateTime TimeStamp { get; set; }
    public double? SpeedInMbps { get; set; }
}

