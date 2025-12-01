using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations;

public static class DbConfigurations
{
    public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
    {
        var connectionString = "Server=localhost,1433;Database=MyVaccine_Db;User Id=sa;Password=Abc.123456;TrustServerCertificate=True;";
        //var connectionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
        services.AddDbContext<MyVaccineAppDbContext>(options =>
            options.UseSqlServer(
                        connectionString
                        )
            );
        return services;
    }
}