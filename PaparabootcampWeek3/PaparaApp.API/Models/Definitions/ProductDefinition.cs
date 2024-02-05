using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Definitions
{
    public class ProductDefinition
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockCount { get; set; }
        public Product Product { get; set; } = default!;
    }
}