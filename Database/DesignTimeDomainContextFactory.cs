using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Models;

namespace Database
{
    /// <summary>
    /// Enables designing the database (for example, adding migrations) using dotnet ef locally, against local database.
    /// </summary>
    public class DesignTimeDomainContextFactory : IDesignTimeDbContextFactory<DomainContext>
    {
        public DomainContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("Synonyms");
            var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
            optionsBuilder.UseSqlite(connectionString);
            return new DomainContext(optionsBuilder.Options);
        }
    }
}
