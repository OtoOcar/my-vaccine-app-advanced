using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registrar todos los validadores del ensamblado
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


builder.Services.AddDbContext<MyVaccineAppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("default"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,                      // número de reintentos
                maxRetryDelay: TimeSpan.FromSeconds(10), // tiempo máximo entre reintentos
                errorNumbersToAdd: null                 // puedes especificar errores adicionales si quieres
            );
        }));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();