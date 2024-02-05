

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Features;

public class ProductFeature
{
    public int Id { get; set; }
    public int Height { get; set; } = default!;
    public int Width { get; set; } = default!;
    public string Color { get; set; } = default!;
    public int ProductId { get; set; } = default!;
    public Product Product { get; set; } = default!;
}