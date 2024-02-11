using AutoMapper;
using RentalHouseApi.DTOs;
using RentalHouseApi.DTOs.Apartment;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Models;
using RentalHouseApi.Repositories;
using RentalHouseApi.UnitOfWorks;

namespace RentalHouseApi.Services
{
    public class TenantSqlService : ITenantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        public TenantSqlService(IMapper mapper, ITenantRepository tenantRepository, IApartmentRepository apartmentRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tenantRepository = tenantRepository;
            _apartmentRepository = apartmentRepository;
        }
        public ResponseDto<Guid> Add(AddTenantDtoRequest request)
        {
            var tenant = _mapper.Map<Tenant>(request);
            _tenantRepository.Add(tenant!);
            _unitOfWork.Commit();
            return ResponseDto<Guid>.Success(tenant!.Id);

        }

        public void Delete(Guid id)
        {
            _tenantRepository.Delete(id);

        }
        public ResponseDto<List<GetTenantDto>> GetAll()
        {
            var tenants = _tenantRepository.GetAll();
            var tenantsDto = _mapper.Map<List<GetTenantDto>>(tenants);
            var response = ResponseDto<List<GetTenantDto>>.Success(tenantsDto!);
            return tenantsDto!.Count > 0 ? response : ResponseDto<List<GetTenantDto>>.Fail("No tenants found");
        }

        public ResponseDto<GetTenantDto> GetById(Guid id)
        {
            var tenant = _tenantRepository.GetById(id);
            if (tenant != null)
            {
                var tenantDto = _mapper.Map<GetTenantDto>(tenant);
                return ResponseDto<GetTenantDto>.Success(tenantDto!);
            }
            throw new Exception("Tenant not found");
        }


        public void Update(AddTenantDtoRequest request, Guid id)
        {
            var tenant = _tenantRepository.GetById(id);
            if (tenant == null)
            {
                throw new Exception("Tenant not found");
            }
            tenant.TenantName = request.TenantName;
            tenant.Surname = request.Surname;
            tenant.PhoneNumber = request.PhoneNumber;
            tenant.Email = request.Email;
            tenant.TcNo = request.TcNo;
            _tenantRepository.Update(tenant);
        }

        public void MatchTenantToApartment(MatchApartmentTenantDtoRequest request)
        {
            var tenant = _tenantRepository.GetById(request.TenantId);
            if (tenant == null)
            {
                throw new Exception("Tenant not found");
            }

            var apartment = _apartmentRepository.GetById(request.ApartmentId);
            if (apartment == null)
            {
                throw new Exception("Apartment not found");
            }
            // Check if the apartment already has a tenant assigned
            if (apartment.TenantId != null)
            {
                throw new Exception("Apartment already has a tenant assigned");
            }

            apartment.Tenant = tenant;
            _apartmentRepository.Update(apartment);
            _unitOfWork.Commit();
            var apartmentDto = _mapper.Map<GetApartmentDto>(apartment);
            apartmentDto!.IsEmpty = false;
        }
    }
}