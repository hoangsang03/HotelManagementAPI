using HotelManagementAPI;
using HotelManagementAPI.Data;
using HotelManagementAPI.Mapping;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("HotelManagementDbConnectionString");

builder.Services.AddDbContext<HotelManagementDbContext>(
    options => options.UseNpgsql(connectionString));

builder.Services
    .AddPresentation(builder.Host)
    .AddMappings()
    .AddAuthen(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
