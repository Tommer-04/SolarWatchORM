using Microsoft.EntityFrameworkCore;
using SolarWatchORM.Data.CityData;
using SolarWatchORM.Data.SunData;

namespace SolarWatchORM.Data
{
    public class SolarWatchContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Sun> SunRecords { get; set; }

        private readonly IConfiguration _config;

        public SolarWatchContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasMany(c => c.SunRecords)
                .WithOne()
                .HasForeignKey(s => s.CityId);


            modelBuilder.Entity<City>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
