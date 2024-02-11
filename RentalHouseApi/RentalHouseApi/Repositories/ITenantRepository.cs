using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Models;
namespace RentalHouseApi.Repositories;
public interface ITenantRepository
{
    List<Tenant> GetAll();
    Tenant Add(Tenant tenant);
    void Update(Tenant tenant);
    void Delete(Guid id);
    Tenant? GetById(Guid id);
    Task<Tenant?> GetTenantForPayment(string userIdString, TenantPaymentDto newTenantPayment);
}