using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;
using MyVaccine.WebApi.Services;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Configurations;

public static class DependencyInjections
{
    public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
    {
        #region Repositories Injection
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBaseRepository<Dependent>, BaseRepository<Dependent>>();
        services.AddScoped<IAllergyRepository, AllergyRepository>();
        services.AddScoped<IVaccineCategoryRepository, VaccineCategoryRepository>();
        services.AddScoped<IVaccineRepository, VaccineRepository>();
        services.AddScoped<IVaccineRecordRepository, VaccineRecordRepository>();
        services.AddScoped<IFamilyGroupRepository, FamilyGroupRepository>();

        #endregion

        #region Services Injection

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDependentService, DependentService>();
        services.AddScoped<IAllergyService, AllergyService>();
        services.AddScoped<IVaccineCategoryService, VaccineCategoryService>();
        services.AddScoped<IVaccineService, VaccineService>();
        services.AddScoped<IVaccineRecordService, VaccineRecordService>();
        services.AddScoped<IFamilyGroupService, FamilyGroupService>();

        #endregion

        #region Only for  testing propourses
        services.AddScoped<IGuidGeneratorScope, GuidServiceScope>();
        services.AddTransient<IGuidGeneratorTrasient, GuidServiceTransient>();
        services.AddSingleton<IGuidGeneratorSingleton, GuidServiceSingleton>();
        services.AddScoped<IGuidGeneratorDeep, GuidGeneratorDeep>();
        #endregion
        return services;
    }
}
