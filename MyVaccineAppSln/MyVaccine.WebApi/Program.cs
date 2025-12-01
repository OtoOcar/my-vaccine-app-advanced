using FluentValidation;
using MyVaccine.WebApi.Configurations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Controllers (NECESARIO)
builder.Services.AddControllers();

// FluentValidation moderno
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// AutoMapper moderno
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(Assembly.GetExecutingAssembly());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraciones propias
builder.Services.SetDatabaseConfiguration();
builder.Services.SetMyVaccineAuthConfiguration();
builder.Services.SetDependencyInjection();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
