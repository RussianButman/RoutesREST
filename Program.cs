using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoutesREST.DbContext;
using RoutesREST.Models.IRepositories;
using RoutesREST.Models.TestRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnectionString")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBypassRouteRepository, TestBypassRouteRepository>();
builder.Services.AddSingleton<IBypassRoutePointRepository, TestBypassRoutePointRepository>();

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

app.Run();