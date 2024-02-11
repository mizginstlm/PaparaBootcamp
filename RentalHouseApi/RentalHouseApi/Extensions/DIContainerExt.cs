using RentalHouseApi.Repositories;
using RentalHouseApi.Services;
using RentalHouseApi.UnitOfWorks;


namespace RentalHouseApi.Extensions;

public static class DIContainerExt
{
    public static void AddDIContainer(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITenantService, TenantSqlService>();
        services.AddScoped<ITenantRepository, TenantSqlRepository>();
        services.AddScoped<IApartmentService, ApartmentSqlService>();
        services.AddScoped<IApartmentRepository, ApartmentSqlRepository>();
        services.AddScoped<IPaymentRepository, PaymentSqlRepository>();
        services.AddScoped<IPaymentService, PaymentSqlService>();
        services.AddScoped<IManagerAuthService, ManagerAuthSqlService>();
        services.AddScoped<ITenantAuthService, TenantAuthSqlService>();
        services.AddScoped<IAuthManagerRepository, ManagerAuthSqlRepository>();
        services.AddScoped<ITenantAuthRepository, TenantAuthSqlRepository>();
        services.AddHttpContextAccessor();

    }
}