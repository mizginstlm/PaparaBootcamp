namespace RentalHouseApi.Models
{

    public class Tenant
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tenant name is required")]
        [StringLength(50, ErrorMessage = "PLease write with a valid length.")]
        public string TenantName { get; set; } = default!;

        public string Surname { get; set; } = default!;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [DataType(DataType.PhoneNumber)]

        public string PhoneNumber { get; set; } = default!;
        public string TcNo { get; set; } = default!;
        public Apartment? Apartment { get; set; }
        public List<Payment> Payments { get; set; } = new List<Payment>();

    }
}