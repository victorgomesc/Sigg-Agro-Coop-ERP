using MediatR;
using Microsoft.EntityFrameworkCore;
using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;
using SiggAgroCoop.Infrastructure.Repositories;
using SiggAgroCoop.Application.Commands.Farms;

using FluentValidation;
using FluentValidation.AspNetCore;
using SiggAgroCoop.Application.Validation.Farms;
using SiggAgroCoop.Application.Validation.Employees;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddControllers();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateFarmCommandValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repositories (Dependency Injection)
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<IPlantingRepository, PlantingRepository>();
builder.Services.AddScoped<IHarvestRepository, HarvestRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeCommandValidator>();

// MediatR (CQRS)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateFarmCommand).Assembly)
);

var app = builder.Build();

// -----------------------------------------------------
// HTTP Request Pipeline
// -----------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Controllers Routing
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
