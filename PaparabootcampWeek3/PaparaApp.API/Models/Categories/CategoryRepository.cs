namespace PaparaApp.API.Models.Categories;

public class CategoryRepository : ICategoryRepository
{

    //private static readonly List<Category> Categories = new();
    private static readonly List<Category> Categories = new();
    public CategoryRepository()
    {
        if (Categories.Count == 0)
        {
            Categories.Add(new Category { Id = 1, Name = "Category 1" });
            Categories.Add(new Category { Id = 2, Name = "Category 2" });
            Categories.Add(new Category { Id = 3, Name = "Category 3" });
            Categories.Add(new Category { Id = 4, Name = "Category 4" });
        }
    }

    public List<Category> GetAllCategories()
    {
        return Categories;
    }


    public Category AddCategory(Category category)
    {
        Categories.Add(category);
        return category;
    }

    public void DeleteCategory(int id)
    {
        var categoryToDeleteIndex = Categories.FindIndex(p => p.Id == id);
        Categories.RemoveAt(categoryToDeleteIndex);
    }

    public Category? GetCategoryById(int id)
    {
        return Categories.FirstOrDefault(p => p.Id == id);
    }
}
