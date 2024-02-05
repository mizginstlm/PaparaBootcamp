
using PaparaApp.API.Migrations;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.Definitions;
using PaparaApp.API.Models.Features;
using PaparaApp.API.Models.Users;
namespace PaparaApp.API.Models.Products;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public int? UserId { get; set; }
    public User? User { get; set; }
    public ProductDefinition ProductDefinitons { get; set; } = default!;
    public ProductFeature ProductFeatures { get; set; } = default!;
}