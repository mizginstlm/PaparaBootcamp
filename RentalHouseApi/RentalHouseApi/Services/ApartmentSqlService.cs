

using AutoMapper;
using RentalHouseApi.DTOs.Apartment;
using RentalHouseApi.Models;
using RentalHouseApi.Repositories;
using RentalHouseApi.UnitOfWorks;

namespace RentalHouseApi.Services;

public class ApartmentSqlService : IApartmentService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IApartmentRepository _apartmentRepository;
    public ApartmentSqlService(IMapper mapper, IApartmentRepository apartmentRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _apartmentRepository = apartmentRepository;
    }

    public ResponseDto<Guid> Add(AddApartmentDtoRequest request)
    {
        var apartment = _mapper.Map<Apartment>(request);
        var addedApartment = _apartmentRepository.Add(apartment!);
        _unitOfWork.Commit();
        return addedApartment != null
            ? ResponseDto<Guid>.Success(addedApartment.Id)
            : ResponseDto<Guid>.Fail("Apartment could not be added.");


    }

    public void Delete(Guid id)
    {
        var apartment = _apartmentRepository.GetById(id);
        if (apartment != null)
        {
            _apartmentRepository.Delete(apartment);
        }
        _unitOfWork.Commit();
    }

    public ResponseDto<List<GetApartmentDto>> GetAll()
    {
        var apartments = _apartmentRepository.GetAll();
        var apartmentsDto = _mapper.Map<List<GetApartmentDto>>(apartments);
        return ResponseDto<List<GetApartmentDto>>.Success(apartmentsDto!);
    }

    public ResponseDto<GetApartmentDto> GetById(Guid id)
    {
        var apartment = _apartmentRepository.GetById(id);
        if (apartment != null)
        {
            var apartmentDto = _mapper.Map<GetApartmentDto>(apartment);
            return ResponseDto<GetApartmentDto>.Success(apartmentDto!);
        }
        return ResponseDto<GetApartmentDto>.Fail("Apartment not found.");
    }


    public void Update(AddApartmentDtoRequest request)
    {
        var apartment = _mapper.Map<Apartment>(request);
        _apartmentRepository.Update(apartment!);
        _unitOfWork.Commit();
    }
}