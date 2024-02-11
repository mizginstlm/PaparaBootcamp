using Microsoft.EntityFrameworkCore.Storage;

namespace RentalHouseApi.UnitOfWorks
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();

        IDbContextTransaction BeginTransaction();
    }
}