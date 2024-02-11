namespace RentalHouseApi.Repositories
{
    public interface IAuthManagerRepository
    {
        public Task<Manager?> GetByNameAsync(string managerName);
    }
}