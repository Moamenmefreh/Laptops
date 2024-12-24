using AutoMapper;
using Laptops.Data;
using Laptops.Model;
using Laptops.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(option=>option.
UseSqlServer(builder.Configuration.GetConnectionString("defualtConnection")));
builder.Services.AddScoped<ICrud<Laptop>, Crud<Laptop>>();
builder.Services.AddScoped<ICrud<Processor>, Crud<Processor>>();
builder.Services.AddScoped<ICrud<Ram>, Crud<Ram>>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddAutoMapper(typeof(Program));
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

app.Run();
