using System.ComponentModel.DataAnnotations;

namespace PaparaApp.API.Models.Categories.DTOs;

public class CategoryAddDtoRequest
{
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Ürün kategori adı 3 ile 10 karakter arasında olmalıdır.")]
    [Required(ErrorMessage = "Kategori adı boş geçilemez!")]
    public string Name { get; set; } = null!;
}