using SolarWatchORM.Data.CityData;

namespace SolarWatchORM.Service.CityRepo
{
    public interface ICityRepo
    {
        Task<City?> SearchByName(string name);
        Task AddNewCity(City city);
    }
}
