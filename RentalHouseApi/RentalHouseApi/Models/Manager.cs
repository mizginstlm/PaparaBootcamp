namespace RentalHouseApi.Models;

public class Manager
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Must have a name.")] public string ManagerName { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = new byte[0];
    public byte[] PasswordSalt { get; set; } = new byte[0];

}