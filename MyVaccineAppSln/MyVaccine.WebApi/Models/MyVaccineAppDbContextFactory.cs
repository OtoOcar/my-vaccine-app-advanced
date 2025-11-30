using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyVaccine.WebApi.Models;

public class MyVaccineAppDbContextFactory : IDesignTimeDbContextFactory<MyVaccineAppDbContext>
{
    public MyVaccineAppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("default");

        var optionsBuilder = new DbContextOptionsBuilder<MyVaccineAppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new MyVaccineAppDbContext(optionsBuilder.Options);
    }
}