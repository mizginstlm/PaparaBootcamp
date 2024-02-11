using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalHouseApi.Data;

namespace RentalHouseApi.Repositories
{
    public class TenantAuthSqlRepository : ITenantAuthRepository
    {
        private readonly DatabaseContext _context;

        public TenantAuthSqlRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Tenant?> GetByNameAsync(string TcNo)
        {
            return await _context.Tenants.FirstOrDefaultAsync(x => x.TcNo == TcNo);
        }
    }
}