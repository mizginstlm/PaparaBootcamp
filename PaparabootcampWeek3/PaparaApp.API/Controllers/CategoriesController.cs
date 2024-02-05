using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaparaApp.API.Filters;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.Categories.DTOs;

namespace PaparaApp.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(IMapper mapper, ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAllCategories()
    {
        return Ok(_categoryService.GetAllCategories());
    }
    [ServiceFilter(typeof(CategoryNotFoundActionFilter))]
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        return Ok(_categoryService.GetCategoryById(id));
    }


    [HttpPost]
    public IActionResult AddCategory(CategoryAddDtoRequest request)
    {
        var result = _categoryService.AddCategory(request);
        return Created("", result);
    }



    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _categoryService.DeleteCategory(id);
        return NoContent();
    }

}