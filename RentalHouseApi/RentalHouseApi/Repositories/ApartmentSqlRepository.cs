using AutoMapper;
using RentalHouseApi.Data;
using RentalHouseApi.Models;
using RentalHouseApi.UnitOfWorks;

namespace RentalHouseApi.Repositories;

public class ApartmentSqlRepository : IApartmentRepository
{

    private readonly DatabaseContext _context;

    public ApartmentSqlRepository(DatabaseContext context)
    {
        _context = context;
    }



    public Apartment Add(Apartment apartment)
    {
        _context.Apartments.Add(apartment);
        return apartment;
    }

    public void Delete(Apartment apartment)
    {
        _context.Apartments.Remove(apartment);
    }

    public List<Apartment> GetAll()
    {
        var apartments = _context.Apartments.ToList();
        return apartments;
    }

    public Apartment? GetById(Guid id)
    {
        var apartment = _context.Apartments.FirstOrDefault(x => x.Id == id);
        return apartment;
    }

    public void Update(Apartment apartment)
    {
        _context.Apartments.Update(apartment);
    }
}