namespace PaparaApp.API.Models.Definitions
{
    public class ProductDefinitionRepository(AppDbContext context) : IProductDefinitionRepository
    {
        private readonly AppDbContext _context = context;

        public ProductDefinition Save(ProductDefinition productDefinition)
        {
            _context.ProductDefinitions.Add(productDefinition);
            return productDefinition;
        }

        public ProductDefinition? GetById(int id)
        {
            return _context.ProductDefinitions.Find(id);
        }
    }
}