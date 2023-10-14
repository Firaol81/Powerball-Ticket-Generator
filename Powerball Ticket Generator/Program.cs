using Microsoft.EntityFrameworkCore;
using Powerball_Ticket_Generator.Models;

var builder = WebApplication.CreateBuilder(args);

// Add configuration settings from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<LottaryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
