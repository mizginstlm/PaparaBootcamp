using Microsoft.EntityFrameworkCore.Storage;
using RentalHouseApi.Data;

namespace RentalHouseApi.UnitOfWorks
{
    public class UnitOfWork(DatabaseContext context) : IUnitOfWork
    {
        private readonly DatabaseContext _context = context;

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}