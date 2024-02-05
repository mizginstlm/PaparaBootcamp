using Microsoft.EntityFrameworkCore;

namespace PaparaApp.API.Models.Products;

public class ProductRepositoryWithSqlServer(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;

    public List<Product> GetAll()
    {
        var products = _context.Products
        .Include(c => c.Category)
        .ToList();
        return products;
    }
    public Product Add(Product product)
    {
        _context.Products.Add(product);
        return product;
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(int id)
    {
        var product = _context.Products.Find(id);
        _context.Remove(product!);
    }

    public Product? GetById(int id)
    {
        return _context.Products.Find(id);
    }
}