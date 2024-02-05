namespace PaparaApp.API.Models.Features
{
    public class ProductFeatureRepository(AppDbContext context) : IProductFeatureRepository
    {
        private readonly AppDbContext _context = context;

        public ProductFeature Save(ProductFeature productFeature)
        {
            _context.ProductFeatures.Add(productFeature);
            return productFeature;
        }

        public ProductFeature? GetById(int id)
        {
            return _context.ProductFeatures.Find(id);
        }
    }
}