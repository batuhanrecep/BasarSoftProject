using Microsoft.EntityFrameworkCore;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BasarsoftWebAPI.Controllers;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddControllersAsServices();


//Before Autofac
//builder.Services.AddScoped<ControllerBase, DoorsController>(); / gereksiz
//builder.Services.AddScoped<IBasarsoftDbContext, BasarsoftDbContext>(); / gereksiz
//builder.Services.AddScoped<DbContext, BasarsoftDbContext>(); / gereksiz
//builder.Services.AddScoped<IDoorService, DoorService>();
//builder.Services.AddScoped<IDoorDal, EfDoorDal>();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));


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
