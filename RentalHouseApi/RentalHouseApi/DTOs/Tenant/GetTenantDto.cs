
using RentalHouseApi.DTOs.Apartment;
using RentalHouseApi.DTOs.Payment;
using RentalHouseApi.Models;

namespace RentalHouseApi.DTOs;

public class GetTenantDto
{
    public Guid Id { get; set; }


    public string TenantName { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string TcNo { get; set; } = null!;
    public List<GetPaymentDto> Payments { get; set; } = new List<GetPaymentDto>();

}