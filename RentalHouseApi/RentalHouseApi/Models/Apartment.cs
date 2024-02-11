namespace RentalHouseApi.Models;

public class Apartment
{
    public Guid Id { get; set; }
    public bool IsEmpty { get; set; } = true;
    public EApartmentType Class { get; set; }

    [Required(ErrorMessage = "Floor is required.")]
    public int Floor { get; set; }
    public EBlock Block { get; set; }
    public int ApartmentNumber { get; set; } = default!;
    public Guid? TenantId { get; set; }
    public Tenant? Tenant { get; set; }

}

