using Microsoft.EntityFrameworkCore;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BasarsoftWebAPI.Controllers;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddControllersAsServices();


////Before Autofac
//builder.Services.AddScoped<ControllerBase, DoorsController>(); 
//builder.Services.AddScoped<IBasarsoftDbContext, BasarsoftDbContext>(); 
//builder.Services.AddScoped<DbContext, BasarsoftDbContext>(); 
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

//builder.Services.AddCors(p => p.AddPolicy("AllowOrigin", builder =>

//{

//    builder.WithOrigins("https://localhosst:71x84").AllowAnyMethod().AllowAnyHeader();

//}));

var Configuration = builder.Configuration;

var tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>

{

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters

    {
        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidIssuer = tokenOptions.Issuer,

        ValidAudience = tokenOptions.Audience,

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        
    };

});



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
