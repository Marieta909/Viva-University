//List<NetworkSpeed> networkSpeedRecords = new()
//{
//    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 0, 0), SpeedInMbps = 50.0 },
//    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 5, 0) },
//    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 10, 0), SpeedInMbps = 70.0 },
//    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 15, 0) },
//    new NetworkSpeed { TimeStamp = new DateTime(2023, 1, 1, 10, 25, 0), SpeedInMbps = 75.0 }
//};

//DateTime startDate = new(2023, 1, 1, 10, 0, 0);
//DateTime endDate = new(2023, 1, 1, 10, 20, 0);

//double averageSpeed = networkSpeedRecords.CalculateAverageSpeed(startDate, endDate);

//Console.WriteLine($"Average Speed: {averageSpeed} Mbps");

//public static class EnumerableExtensions
//{
//    public static double CalculateAverageSpeed(this IEnumerable<NetworkSpeed> networkSpeedRecords, DateTime startDate, DateTime endDate)
//    {
//        var filteredRecords = networkSpeedRecords
//            .Where(record => record.TimeStamp >= startDate && record.TimeStamp <= endDate && record.SpeedInMbps.HasValue)
//            .ToList();

//        if (filteredRecords.Count == 0)
//            return 0.0;

//        double totalSpeed = filteredRecords.Sum(record => record.SpeedInMbps.Value);
//        double averageSpeed = totalSpeed / filteredRecords.Count;
//        return averageSpeed;
//    }
//}


//public class NetworkSpeed
//{
//    public DateTime TimeStamp { get; set; }
//    public double? SpeedInMbps { get; set; }
//}


// Mbps/8

List<NetworkSpeed> networkSpeedRecords = new List<NetworkSpeed>
{
    new NetworkSpeed { TimeStamp = DateTime.Now.AddMinutes(-10), DownloadSpeedInMbps = 50.0, UploadSpeedInMbps = 20.0 },
    new NetworkSpeed { TimeStamp = DateTime.Now.AddMinutes(-5), DownloadSpeedInMbps = 60.0, UploadSpeedInMbps = 25.0 },
    new NetworkSpeed { TimeStamp = DateTime.Now, DownloadSpeedInMbps = 70.0, UploadSpeedInMbps = 30.0 },
    new NetworkSpeed { TimeStamp = DateTime.Now.AddMinutes(5), DownloadSpeedInMbps = 55.0, UploadSpeedInMbps = 35.0 },
    new NetworkSpeed { TimeStamp = DateTime.Now.AddMinutes(10), DownloadSpeedInMbps = 65.0, UploadSpeedInMbps = 40.0 }
};

DateTime startTime = DateTime.Now.AddMinutes(-15);
DateTime endTime = DateTime.Now.AddMinutes(5);

double bandwidthUsage = networkSpeedRecords.CalculateBandwidthUsage(startTime, endTime);

Console.WriteLine($"Bandwidth Usage: {bandwidthUsage} Mbps");

public static class EnumerableExtensions
{
    public static double CalculateBandwidthUsage(this IEnumerable<NetworkSpeed> networkSpeedRecords, DateTime startTime, DateTime endTime)
    {
        var filteredRecords = networkSpeedRecords
            .Where(record => record.TimeStamp >= startTime && record.TimeStamp <= endTime)
            .ToList();

        if (!filteredRecords.Any())
            return 0.0;

        double totalDownloadSpeed = filteredRecords.Sum(record => record.DownloadSpeedInMbps);
        double totalUploadSpeed = filteredRecords.Sum(record => record.UploadSpeedInMbps);

        double bandwidthUsage = (totalDownloadSpeed + totalUploadSpeed) / filteredRecords.Count();
        return bandwidthUsage;
    }
}

public class NetworkSpeed
{
    public DateTime TimeStamp { get; set; }
    public double DownloadSpeedInMbps { get; set; }
    public double UploadSpeedInMbps { get; set; }
}