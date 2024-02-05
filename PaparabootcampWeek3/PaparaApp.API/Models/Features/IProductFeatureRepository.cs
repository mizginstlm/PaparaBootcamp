namespace PaparaApp.API.Models.Features
{
    public interface IProductFeatureRepository
    {
        ProductFeature Save(ProductFeature productFeature);
        ProductFeature? GetById(int id);
    }
}