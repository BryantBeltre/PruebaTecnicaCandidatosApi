using ApiRestFullPruebaTecnica.Application.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.DTOs;
using ApiRestFullPruebaTecnica.Application.Handlers.Commands.Auth;
using ApiRestFullPruebaTecnica.Application.Handlers.Queries.Metrics;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Application.Interfaces.Auth;
using ApiRestFullPruebaTecnica.Domain.Entities;
using ApiRestFullPruebaTecnica.Infrastructure.Extensions;
using ApiRestFullPruebaTecnica.Infrastructure.Persistence;
using ApiRestFullPruebaTecnica.Infrastructure.Services.Auth;
using ApiRestFullPruebaTecnica.Infrastructure.UniOfWork;
using ApiRestFullPruebaTecnica.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuración Cadena de Conexion BD SqlServer
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion")));

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

//Configuración Registrar el UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Configuración Regitrar AuttoMappert
builder.Services.AddAutoMapper(typeof(LoginCommandHandler).Assembly);

//Configuración MediatR 
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(GetMetricsSummaryQueryHandler).Assembly);
});





//Configuracion Registrar FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

//Configuracion de Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

//Add Controladores
builder.Services.AddControllers();

//Add Documentación con Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configuracion Logging con Serilog
builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .ReadFrom.Configuration(ctx.Configuration));


//Configuración de la Autenticación JWT
//builder.Services.AddJwtAuthentication(builder.Configuration);


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

app.UseSerilogRequestLogging();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//Middleware de manejo de excepciones
//app.UseMiddleware<ExceptionHandlingMiddleware>();

//Middleware de métricas
app.UseMiddleware<ApiMetricsMiddleware>();

app.MapControllers();

app.Run();
