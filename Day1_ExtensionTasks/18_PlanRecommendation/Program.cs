List<CallRecord> callRecords = new List<CallRecord>
{
    new CallRecord { Date = DateTime.Now.AddDays(-1), Duration = TimeSpan.FromMinutes(20) },
    new CallRecord { Date = DateTime.Now.AddDays(-2), Duration = TimeSpan.FromMinutes(30) },
    new CallRecord { Date = DateTime.Now.AddDays(-3), Duration = TimeSpan.FromMinutes(15) }
};

List<DataUsage> dataUsageRecords = new List<DataUsage>
{
    new DataUsage { Date = DateTime.Now.AddDays(-1), UsageInGB = 1.5 },
    new DataUsage { Date = DateTime.Now.AddDays(-2), UsageInGB = 3.0 },
    new DataUsage { Date = DateTime.Now.AddDays(-3), UsageInGB = 0.5 }
};

string recommendedPlan = callRecords.RecommendPlan(dataUsageRecords);

Console.WriteLine($"Recommended Plan: {recommendedPlan}");

public static class PricingPlanExtensions
{
    public static string RecommendPlan(this IEnumerable<CallRecord> callRecords, IEnumerable<DataUsage> dataUsageRecords)
    {
        double totalCallDurationMinutes = callRecords.Sum(record => record.Duration.TotalMinutes);
        double totalDataUsageGB = dataUsageRecords.Sum(record => record.UsageInGB);

        if (totalCallDurationMinutes <= 300 && totalDataUsageGB <= 2)
        {
            return "Basic Plan";
        }
        else if (totalCallDurationMinutes <= 600 && totalDataUsageGB <= 5)
        {
            return "Standard Plan";
        }
        else if (totalCallDurationMinutes <= 1200 && totalDataUsageGB <= 10)
        {
            return "Premium Plan";
        }
        else
        {
            return "Custom Plan";
        }
    }
}


public class CallRecord
{
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
}

public class DataUsage
{
    public DateTime Date { get; set; }
    public double UsageInGB { get; set; }
}