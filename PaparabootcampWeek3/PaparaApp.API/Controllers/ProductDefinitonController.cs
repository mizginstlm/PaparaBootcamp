using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaparaApp.API.Models.Features;
using PaparaApp.API.Models.Features.DTOs;

namespace PaparaApp.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductFeatureController : ControllerBase
{
    private readonly IProductFeatureService _productFeatureService;

    public ProductFeatureController(IMapper mapper, IProductFeatureService productFeatureService)
    {
        _productFeatureService = productFeatureService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_productFeatureService.GetProductFeatureById(id));
    }


    [HttpPost]
    public IActionResult Save(ProductFeatureAddDtoRequest request)
    {
        var result = _productFeatureService.Save(request);
        return Created("", result);
    }

}