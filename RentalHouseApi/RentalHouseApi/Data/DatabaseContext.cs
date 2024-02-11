using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace RentalHouseApi.Data;
public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seeding manager
        byte[] passwordHash;
        byte[] passwordSalt;
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;//random
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:ManagerPassword").Value!));
        }

        var manager = new Manager { Id = Guid.NewGuid(), ManagerName = "admin", PasswordHash = passwordHash, PasswordSalt = passwordSalt };
        modelBuilder.Entity<Manager>().HasData(manager);

        modelBuilder.Entity<Payment>()
        .Property(p => p.Amount)
        .HasColumnType("decimal(18,2)");
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Apartment> Apartments { get; set; } = default!;
    public DbSet<Tenant> Tenants { get; set; } = default!;
    public DbSet<Payment> Payments { get; set; } = default!;
    public DbSet<Manager> Manager { get; set; } = default!;

}