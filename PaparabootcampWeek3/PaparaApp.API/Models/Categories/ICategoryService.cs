using PaparaApp.API.Models.Categories.DTOs;
using PaparaApp.API.Models.Shared;

namespace PaparaApp.API.Models.Categories;

public interface ICategoryService
{
    ResponseDto<List<CategoryDto>> GetAllCategories();

    ResponseDto<CategoryDto> GetCategoryById(int id);
    void DeleteCategory(int id);
    ResponseDto<int> AddCategory(CategoryAddDtoRequest request);
}