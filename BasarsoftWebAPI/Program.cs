using Microsoft.EntityFrameworkCore;
using System;
using BasarsoftWebAPI.Controllers;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddControllersAsServices();

builder.Services.AddScoped<ControllerBase, DoorsController>();
builder.Services.AddScoped<IBasarsoftDbContext, BasarsoftDbContext>();
builder.Services.AddScoped<DbContext, BasarsoftDbContext>();


builder.Services.AddScoped<IDoorService, DoorService>();
builder.Services.AddScoped<IDoorDal, EfDoorDal>();

builder.Services.AddDbContext<BasarsoftDbContext>(options =>
{
    var serviceProvider = builder.Services.BuildServiceProvider();
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    //options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
});




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
