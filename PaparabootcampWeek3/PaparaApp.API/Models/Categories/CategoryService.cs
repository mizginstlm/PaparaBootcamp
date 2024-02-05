using AutoMapper;
using PaparaApp.API.Models.Categories.DTOs;
using PaparaApp.API.Models.Shared;

namespace PaparaApp.API.Models.Categories;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }


    public void DeleteCategory(int id)
    {
        _categoryRepository.DeleteCategory(id);
        ResponseDto<int>.Success(id);
    }

    public ResponseDto<List<CategoryDto>> GetAllCategories()
    {
        var categorys = _categoryRepository.GetAllCategories();

        var categoryDtos = _mapper.Map<List<CategoryDto>>(categorys);

        return ResponseDto<List<CategoryDto>>.Success(categoryDtos);
    }

    public ResponseDto<int> AddCategory(CategoryAddDtoRequest request)
    {
        var id = new Random().Next(1, 1000);


        var category = new Category
        {
            Id = id,
            Name = request.Name,
        };

        _categoryRepository.AddCategory(category);
        return ResponseDto<int>.Success(id);
    }

    public ResponseDto<CategoryDto> GetCategoryById(int id)
    {
        var data = _categoryRepository.GetCategoryById(id);

        var category = _mapper.Map<CategoryDto>(data);
        return ResponseDto<CategoryDto>.Success(category);
    }


}