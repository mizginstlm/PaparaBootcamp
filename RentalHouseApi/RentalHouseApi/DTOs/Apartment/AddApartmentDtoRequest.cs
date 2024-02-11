using System.ComponentModel.DataAnnotations;
using RentalHouseApi.Models;
namespace RentalHouseApi.DTOs.Apartment;

public class AddApartmentDtoRequest
{
    [Required(ErrorMessage = "Status is required.")]
    public bool IsEmpty { get; set; }

    [Required(ErrorMessage = "Class is required.")]
    [EnumDataType(typeof(EApartmentType), ErrorMessage = "Invalid class type.")]
    public EApartmentType Class { get; set; }

    [Required(ErrorMessage = "Floor is required.")]
    [Range(0, 10, ErrorMessage = "Floor must be greater than 0 and less than 10")]
    public int Floor { get; set; }

    [Required(ErrorMessage = "Block is required.")]
    [EnumDataType(typeof(EBlock), ErrorMessage = "Invalid block type.")]
    public EBlock Block { get; set; }

    [Range(0, 5, ErrorMessage = "Apartment Number must be greater than 0 and less than 5")]
    public int ApartmentNumber { get; set; } = default!;
}