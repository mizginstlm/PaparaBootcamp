using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaparaApp.API.Migrations;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.Categories.DTOs;
using PaparaApp.API.Models.Definitions;
using PaparaApp.API.Models.Definitions.DTOs;

namespace PaparaApp.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductDefinitionController : ControllerBase
{
    private readonly IProductDefinitionService _productDefinitionService;

    public ProductDefinitionController(IMapper mapper, IProductDefinitionService productDefinitionService)
    {
        _productDefinitionService = productDefinitionService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_productDefinitionService.GetProductDefinitionById(id));
    }


    [HttpPost]
    public IActionResult Save(ProductDefinitionAddDtoRequest request)
    {
        var result = _productDefinitionService.Save(request);
        return Created("", result);
    }

}