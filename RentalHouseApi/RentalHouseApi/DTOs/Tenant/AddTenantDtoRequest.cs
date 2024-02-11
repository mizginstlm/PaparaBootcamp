
namespace RentalHouseApi.DTOs.Tenant;

public class AddTenantDtoRequest
{

    [MinLength(2, ErrorMessage = "Tenant name must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "Tenant name must be at most 50 characters")]
    public string TenantName { get; set; } = null!;

    [MinLength(2, ErrorMessage = "Tenant name must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "Tenant name must be at most 50 characters")]
    public string Surname { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Please write a valid email.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^5\d{9}$", ErrorMessage = "Please write a valid Turkish phone number starting with 5.")]
    [DataType(DataType.PhoneNumber)]
    [MinLength(10, ErrorMessage = "Please write a valid phone number.")]
    public string PhoneNumber { get; set; } = null!;

    [MinLength(11, ErrorMessage = "Please write a valid Tc number.")]
    [MaxLength(11, ErrorMessage = "Please write a valid Tc number.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Please write a valid Tc number.")]
    public string TcNo { get; set; } = null!;


}