namespace RentalHouseApi.Mappings;
using AutoMapper;
using RentalHouseApi.DTOs;
using RentalHouseApi.DTOs.Apartment;
using RentalHouseApi.DTOs.Manager;
using RentalHouseApi.DTOs.Payment;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Models;

public class DtoProfile : Profile
{//editleme reverse mapleri
    public DtoProfile()
    {
        CreateMap<Tenant, GetTenantDto>();
        CreateMap<AddTenantDtoRequest, Tenant>();
        CreateMap<Apartment, GetApartmentDto>().ReverseMap();
        CreateMap<Payment, GetPaymentDto>().ReverseMap();
        CreateMap<Payment, AddPaymentDtoRequest>().ReverseMap();
        CreateMap<Manager, ManagerDto>().ReverseMap();
        CreateMap<AddApartmentDtoRequest, Apartment>().ReverseMap();
        CreateMap<TenantPaymentDto, Payment>();
    }
}