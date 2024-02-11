
using Microsoft.EntityFrameworkCore;
using RentalHouseApi.Data;

namespace RentalHouseApi.Repositories
{

    public class ManagerAuthSqlRepository : IAuthManagerRepository
    {
        private readonly DatabaseContext _context;

        public ManagerAuthSqlRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Manager?> GetByNameAsync(string managerName)
        {
            return await _context.Manager.FirstOrDefaultAsync(x => x.ManagerName == managerName);
        }

    }
}