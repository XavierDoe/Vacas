using HistorialVacunacions.Repositories;
using Inventarios.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Vacas.Models;
using Vacas.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path for appsettings.json
           .AddJsonFile("appsettings.json") // Add the appsettings.json file
           .Build();

var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
builder.Services.AddSingleton<IMongoClient>(mongoClient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IVaca, VacaI>();
builder.Services.AddTransient<ITrabajador, TrabajadorI>();
builder.Services.AddTransient<IHistorialVacunacion, HistorialVacunacionI>();
builder.Services.AddTransient<IInventario, InventarioI>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
