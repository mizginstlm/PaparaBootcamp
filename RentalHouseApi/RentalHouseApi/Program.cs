global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using RentalHouseApi.DTOs;
global using System.ComponentModel.DataAnnotations;
global using RentalHouseApi.Models;
using Microsoft.EntityFrameworkCore;
using RentalHouseApi.Data;
using RentalHouseApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = """Standard Authorization header using the Bearer scheme. Example: "bearer {token}" """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//auth scheme
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),//null forgiving operator(!)
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAutoMapper(typeof(Program).Assembly);//
builder.Services.AddHttpContextAccessor();
builder.Services.AddDIContainer();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.AddExceptionMiddleware();
app.AddDefaultMiddlewaresExt();
app.Run();
