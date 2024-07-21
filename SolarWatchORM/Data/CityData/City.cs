using SolarWatchORM.Data.SunData;

namespace SolarWatchORM.Data.CityData
{
    public class City
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Longitude { get; init; }
        public double Latitude { get; init; }
        public string? State { get; init; }
        public string Country { get; init; }

        public ICollection<Sun> SunRecords { get; set; } = new List<Sun>();
    }
}
