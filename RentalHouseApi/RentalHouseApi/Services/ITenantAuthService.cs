
namespace RentalHouseApi.Services
{
    public interface ITenantAuthService
    {
        Task<ResponseDto<string>> LoginForTenant(string TcNo, string PhoneNumber);
    }
}