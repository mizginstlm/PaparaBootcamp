using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PaparaApp.API.Extensions;
using PaparaApp.API.Filters;
using PaparaApp.API.Models;
using PaparaApp.API.Models.Products;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddMemoryCache(options =>
{
    // options.SizeLimit = 200;
    // options.ExpirationScanFrequency = TimeSpan.FromMinutes(1);
    // options.CompactionPercentage = 0.2;
});

// builder.Services.AddStackExchangeRedisCache(options =>
// {
//     options.Configuration = builder.Configuration.GetConnectionString("Redis");
// });


builder.Services.AddProductDIContainer();
// builder.Services.AddControllers(x => { x.Filters.Add<NotFoundActionFilter>(); });
builder.Services.AddControllers(x => { x.Filters.Add<CategoryNotFoundActionFilter>(); });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.AddAutoMapper(typeof(Program));//AutoMapper
builder.Services.AddScoped<NotFoundActionFilter>();
builder.Services.AddScoped<CategoryNotFoundActionFilter>();


var app = builder.Build();
app.AddExceptionMiddleware();
app.AddDefaultMiddlewaresExt();


app.Run();