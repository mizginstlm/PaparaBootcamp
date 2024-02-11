namespace RentalHouseApi.Services;

public interface IManagerAuthService
{
    Task<ResponseDto<string>> LoginForManager(string managerName, string password);

}