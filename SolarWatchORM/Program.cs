using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SolarWatchORM.Data;
using SolarWatchORM.Data.CityData;
using SolarWatchORM.Service.CityDataProvider;
using SolarWatchORM.Service.CityRepo;
using SolarWatchORM.Service.SunDataProvider;
using SolarWatchORM.Service.SunRepo;
using SolarWatchORM.Service.UserService;
using System;
using System.Text;
using SolarWatchORM.Configurations;
using SolarWatchORM.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json"); // Load appsettings.json
builder.Configuration.AddUserSecrets<Program>();


builder.Services.AddSingleton<ICityDataProvider, CityDataProvider>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddSingleton<ISunDataProvider, SunDataProvider>();
builder.Services.AddScoped<ISunRepo, SunRepo>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Application DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SolarWatchContext>(options => options.UseSqlServer(connectionString));

// Configure Identity DbContext
builder.Services.AddDbContext<IdentityContext>(options =>options.UseSqlServer(connectionString));

// Add Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

// Register the UserService
builder.Services.AddScoped<UserService>(); 



var jwtSettings = builder.Configuration.GetSection("Jwt");
var issuerSigningKey = builder.Configuration["Jwt:IssuerSigningKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["ValidIssuer"],
        ValidAudience = jwtSettings["ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey))
    };
});

builder.Services.AddScoped<JwtTokenHelper>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
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


