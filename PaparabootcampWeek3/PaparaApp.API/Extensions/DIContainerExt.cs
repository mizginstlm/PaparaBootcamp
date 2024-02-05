using PaparaApp.API.Models.Definitions;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.Features;
using PaparaApp.API.Models.UnitOfWorks;
namespace PaparaApp.API.Models.Products;

public static class ProductDIContainerExt
{
    public static void AddProductDIContainer(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepositoryWithSqlServer>();
        services.AddScoped<IProductService, ProductServiceWithSqlServer>();
        services.AddScoped<IProductDefinitionRepository, ProductDefinitionRepository>();
        services.AddScoped<ProductHelper>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepositoryWithSqlServer>();
        services.AddScoped<ICategoryService, CategoryServiceWithSqlServer>();
        services.AddScoped<IProductDefinitionRepository, ProductDefinitionRepository>();
        services.AddScoped<IProductDefinitionService, ProductDefinitionService>();
        services.AddScoped<IProductFeatureRepository, ProductFeatureRepository>();
        services.AddScoped<IProductFeatureService, ProductFeatureService>();
    }
}