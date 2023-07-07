List<CallRecord> callRecords = new List<CallRecord>
        {
            new CallRecord { Date = new DateTime(2023, 1, 1), Duration = TimeSpan.FromMinutes(10), Cost = 5.0m },
            new CallRecord { Date = new DateTime(2023, 1, 2), Duration = TimeSpan.FromMinutes(15), Cost = 7.5m },
            new CallRecord { Date = new DateTime(2023, 1, 3), Duration = TimeSpan.FromMinutes(5), Cost = 2.5m },
            new CallRecord { Date = new DateTime(2023, 1, 4), Duration = TimeSpan.FromMinutes(20), Cost = 10.0m }
        };

DateTime startDate = new DateTime(2023, 1, 2);
DateTime endDate = new DateTime(2023, 1, 4);

(TimeSpan totalDuration, decimal totalCost) = callRecords.CalculateTotalDurationAndCost(startDate, endDate);

Console.WriteLine($"Total Duration: {totalDuration.TotalMinutes} minutes");
Console.WriteLine($"Total Cost: ${totalCost}");


public static class EnumerableExtensions
{
    public static (TimeSpan totalDuration, decimal totalCost) CalculateTotalDurationAndCost(this IEnumerable<CallRecord> callRecords, DateTime startDate, DateTime endDate)
    {
        var filteredCalls = callRecords.Where(cr => cr.Date >= startDate && cr.Date <= endDate);
        var totalDuration = filteredCalls.Sum(cr => cr.Duration.Ticks);
        var totalCost = filteredCalls.Sum(cr => (double)cr.Cost);
        return (TimeSpan.FromTicks(totalDuration), (decimal)totalCost);
    }
}

public class CallRecord
{
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Cost { get; set; }
}

