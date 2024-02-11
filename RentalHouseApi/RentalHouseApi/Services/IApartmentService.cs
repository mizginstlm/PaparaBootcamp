using RentalHouseApi.DTOs.Apartment;

namespace RentalHouseApi.Services;

public interface IApartmentService
{
    ResponseDto<List<GetApartmentDto>> GetAll();
    ResponseDto<GetApartmentDto> GetById(Guid id);
    void Delete(Guid id);
    ResponseDto<Guid> Add(AddApartmentDtoRequest request);
    void Update(AddApartmentDtoRequest request);
}