using SolarWatchORM.Data;
using SolarWatchORM.Data.CityData;
using SolarWatchORM.Service.CityDataProvider;
using SolarWatchORM.Service.CityRepo;
using SolarWatchORM.Service.SunDataProvider;
using SolarWatchORM.Service.SunRepo;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json"); // Load appsettings.json
builder.Services.AddDbContext<SolarWatchContext>(); // Register DbContext with DI
builder.Services.AddSingleton<ICityDataProvider, CityDataProvider>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddSingleton<ISunDataProvider, SunDataProvider>();
builder.Services.AddScoped<ISunRepo, SunRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();




void InitializeDb()
{
    var config = builder.Configuration;
    using var db = new SolarWatchContext(config);
}

InitializeDb();



app.Run();


