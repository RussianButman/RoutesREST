using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoutesREST.Models;
using RoutesREST.Models.IRepositories;
using RoutesREST.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnectionString"))
        .UseLazyLoadingProxies();
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBypassRouteRepository, BypassRouteRepository>();
builder.Services.AddTransient<IBypassRoutePointRepository, BypassRoutePointRepository>();
builder.Services.AddTransient<IPerformerRepository, PerformerRepository>();

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

SeedData.EnsureCreated(app);

app.Run();