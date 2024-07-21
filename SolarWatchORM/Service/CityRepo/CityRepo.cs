using Microsoft.EntityFrameworkCore;
using SolarWatchORM.Data;
using SolarWatchORM.Data.CityData;

namespace SolarWatchORM.Service.CityRepo
{
    public class CityRepo : ICityRepo
    {
        private readonly SolarWatchContext _context;

        public CityRepo(SolarWatchContext context)
        {
            _context = context;
        }

        public async Task<City?> SearchByName(string name)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task AddNewCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }
    }
}
