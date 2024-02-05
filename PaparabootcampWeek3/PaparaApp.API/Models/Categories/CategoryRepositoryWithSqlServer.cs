using Microsoft.EntityFrameworkCore;

namespace PaparaApp.API.Models.Categories;

public class CategoryRepositoryWithSqlServer(AppDbContext context) : ICategoryRepository
{
    private readonly AppDbContext _context = context;

    public List<Category> GetAllCategories()
    {
        var categoriesWithProductsAndFeatures = _context.Categories
         .Include(c => c.Products)
         .ToList();
        return categoriesWithProductsAndFeatures;
    }

    public Category AddCategory(Category category)
    {
        _context.Categories.Add(category);
        return category;
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        _context.Remove(category!);

    }

    public Category? GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }
}