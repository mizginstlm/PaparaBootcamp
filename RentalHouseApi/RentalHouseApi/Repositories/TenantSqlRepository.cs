using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RentalHouseApi.Data;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Models;
using RentalHouseApi.UnitOfWorks;

namespace RentalHouseApi.Repositories;

public class TenantSqlRepository : ITenantRepository
{

    private readonly DatabaseContext _context;
    public TenantSqlRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Tenant Add(Tenant tenant)
    {
        _context.Tenants.AddAsync(tenant);
        return tenant;
    }

    public void Delete(Guid id)
    {
        var tenant = _context.Tenants.Find(id);
        if (tenant != null)
        {
            _context.Tenants.Remove(tenant);

        }
    }

    public List<Tenant> GetAll()
    {
        var tenants = _context.Tenants.Include(c => c.Apartment).Include(c => c.Payments).ToList();
        var tentapt = _context.Tenants.Include(c => c.Apartment).ToList();
        var tnpay = _context.Tenants.Include(c => c.Payments).ToList();


        return tenants;
    }

    public Tenant? GetById(Guid id)
    {
        return _context.Tenants.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Tenant tenant)
    {
        _context.Tenants.Update(tenant);

    }

    public async Task<Tenant?> GetTenantForPayment(string userIdString, TenantPaymentDto newTenantPayment)
    {
        return await _context.Tenants
                 .FirstOrDefaultAsync(c => c.Id == new Guid(userIdString));
    }
}