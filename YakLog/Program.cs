using Microsoft.EntityFrameworkCore;
using YakLogApi.Persistence;
using YakLogApi.Services.Interfaces;
using YakLogApi.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddYaklogServices();

builder.Services.AddDbContext<YakLogDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();
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

app.Run();
