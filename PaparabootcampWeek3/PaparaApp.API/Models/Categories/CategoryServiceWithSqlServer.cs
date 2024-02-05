using AutoMapper;
using PaparaApp.API.Models.Categories.DTOs;
using PaparaApp.API.Models.Shared;
using PaparaApp.API.Models.UnitOfWorks;

namespace PaparaApp.API.Models.Categories;

public class CategoryServiceWithSqlServer(
    ICategoryRepository categoryRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : ICategoryService
{
    public ResponseDto<List<CategoryDto>> GetAllCategories()
    {
        var categoryList = categoryRepository.GetAllCategories();

        var categoryListWithDto = mapper.Map<List<CategoryDto>>(categoryList);

        return ResponseDto<List<CategoryDto>>.Success(categoryListWithDto);
    }

    public ResponseDto<CategoryDto> GetCategoryById(int id)
    {
        var category = categoryRepository.GetCategoryById(id);
        var categoryResult = mapper.Map<CategoryDto>(category);
        return ResponseDto<CategoryDto>.Success(categoryResult);
    }

    public void DeleteCategory(int id)
    {
        categoryRepository.DeleteCategory(id);
        unitOfWork.Commit();
    }

    public ResponseDto<int> AddCategory(CategoryAddDtoRequest request)
    {
        var category = new Category
        {
            Name = request.Name,
        };
        categoryRepository.AddCategory(category);
        unitOfWork.Commit();

        return ResponseDto<int>.Success(category.Id);
    }


}