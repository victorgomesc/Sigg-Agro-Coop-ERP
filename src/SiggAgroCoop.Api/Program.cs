using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

using SiggAgroCoop.Domain.Interfaces;
using SiggAgroCoop.Infrastructure.Context;
using SiggAgroCoop.Infrastructure.Repositories;
using SiggAgroCoop.Application.Commands.Farms;

using FluentValidation;
using FluentValidation.AspNetCore;
using SiggAgroCoop.Application.Validation.Farms;
using SiggAgroCoop.Application.Validation.Employees;
using SiggAgroCoop.Application.Interfaces;
using SiggAgroCoop.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateFarmCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeCommandValidator>();

// Swagger + JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SiggAgroCoop API",
        Version = "v1"
    });

    // 🔐 JWT Bearer no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite: Bearer {seu token JWT}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Database (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repositories (DI)
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<IPlantingRepository, PlantingRepository>();
builder.Services.AddScoped<IHarvestRepository, HarvestRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();
builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Auth
builder.Services.AddScoped<IAuthService, AuthService>();

// 🔐 JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new Exception("Jwt:Key not configured");

if (jwtKey.Length < 32)
    throw new Exception("Jwt:Key must be at least 32 characters");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey)
        ),

        ClockSkew = TimeSpan.Zero
    };
});

// 🔐 Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",
        policy => policy.RequireRole("Admin"));

    options.AddPolicy("ManagerOnly",
        policy => policy.RequireRole("Admin", "Manager"));

    options.AddPolicy("EmployeeOnly",
        policy => policy.RequireRole("Admin", "Manager", "Employee"));
});

// MediatR (quando for reativar CQRS)
// builder.Services.AddMediatR(cfg =>
//     cfg.RegisterServicesFromAssembly(typeof(CreateFarmCommand).Assembly)
// );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔐 MUITO IMPORTANTE: ordem correta
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
