

namespace PaparaApp.API.Models.Categories;

public interface ICategoryRepository
{
    List<Category> GetAllCategories();
    Category AddCategory(Category category);
    void DeleteCategory(int id);
    Category? GetCategoryById(int id);
}