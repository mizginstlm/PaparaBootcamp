
namespace RentalHouseApi.Repositories;
public interface ITenantAuthRepository
{
    public Task<Tenant?> GetByNameAsync(string TcNo);
}