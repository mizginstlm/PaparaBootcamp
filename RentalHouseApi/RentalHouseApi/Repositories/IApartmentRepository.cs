namespace RentalHouseApi.Repositories;
public interface IApartmentRepository
{
    List<Apartment> GetAll();
    Apartment? GetById(Guid id);
    Apartment Add(Apartment apartment);
    void Update(Apartment apartment);
    void Delete(Apartment apartment);
}