using System.Numerics;

List<PointOfInterest> pois = new List<PointOfInterest>
{
    new PointOfInterest { Name = "Restaurant A", Latitude = 40.7128, Longitude = -74.0060 },
    new PointOfInterest { Name = "Park B", Latitude = 34.0522, Longitude = -118.2437 },
    new PointOfInterest { Name = "Museum C", Latitude = 51.5074, Longitude = -0.1278 },
    new PointOfInterest { Name = "Shopping Mall D", Latitude = 35.6895, Longitude = 139.6917 }
};

GeoLocation location = new GeoLocation { Latitude = 37.7749, Longitude = -122.4194 };

PointOfInterest nearestPOI = location.FindNearestPOI(pois);

Console.WriteLine($"Nearest Point of Interest: {nearestPOI?.Name}");

public static class GeoLocationExtensions
{
    public static PointOfInterest FindNearestPOI(this GeoLocation location, IEnumerable<PointOfInterest> pois)
    {
        Vector2 currentPoint = new Vector2((float)location.Latitude, (float)location.Longitude);
        PointOfInterest nearestPOI = null;
        double minDistance = double.MaxValue;

        foreach (var poi in pois)
        {
            Vector2 poiPoint = new Vector2((float)poi.Latitude, (float)poi.Longitude);
            double distance = Vector2.Distance(currentPoint, poiPoint);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPOI = poi;
            }
        }

        return nearestPOI;
    }
}


public class GeoLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class PointOfInterest
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}