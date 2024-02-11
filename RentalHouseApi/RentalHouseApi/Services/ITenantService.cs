using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalHouseApi.DTOs;
using RentalHouseApi.DTOs.Apartment;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Models;

namespace RentalHouseApi.Services
{
    public interface ITenantService
    {
        ResponseDto<List<GetTenantDto>> GetAll();
        ResponseDto<GetTenantDto> GetById(Guid id);
        void Delete(Guid id);
        ResponseDto<Guid> Add(AddTenantDtoRequest request);
        void Update(AddTenantDtoRequest request, Guid id);
        void MatchTenantToApartment(MatchApartmentTenantDtoRequest request);
    }
}