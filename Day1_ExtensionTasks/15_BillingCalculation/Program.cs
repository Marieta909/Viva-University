List<CallRecord> callRecords = new()
{
    new CallRecord { Date = new DateTime(2023, 1, 1), DurationInMinutes = 10 },
    new CallRecord { Date = new DateTime(2023, 1, 2), DurationInMinutes = 5 },
    new CallRecord { Date = DateTime.Now.AddMinutes(-10), DurationInMinutes = 20 },
};

List<DataUsage> dataUsageRecords = new()
{ 
    new DataUsage { Date = new DateTime(2023, 1, 1), DataInGB = 2.5 },
    new DataUsage { Date = new DateTime(2023, 1, 2), DataInGB = 1.5 },
    new DataUsage { Date = DateTime.Now.AddDays(-3), DataInGB = 3.0 }
};

PricingPlan plan = new()
{
    CallRatePerMinute = 0.25,
    DataRatePerGB = 5.0
};

double totalBill = callRecords.CalculateTotalCost(plan) + dataUsageRecords.CalculateTotalCost(plan);

Console.WriteLine($"Total Bill: {totalBill}");

public static class EnumerableExtensions
{
    public static double CalculateTotalCost(this IEnumerable<CallRecord> callRecords, PricingPlan plan)
    {
        double totalCost = callRecords.Sum(call => call.DurationInMinutes * plan.CallRatePerMinute);
        return totalCost;
    }

    public static double CalculateTotalCost(this IEnumerable<DataUsage> dataUsageRecords, PricingPlan plan)
    {
        double totalCost = dataUsageRecords.Sum(data => data.DataInGB * plan.DataRatePerGB);
        return totalCost;
    }
}


public class CallRecord
{
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }
}

public class DataUsage
{
    public DateTime Date { get; set; }
    public double DataInGB { get; set; }
}

public class PricingPlan
{
    public double CallRatePerMinute { get; set; }
    public double DataRatePerGB { get; set; }
}