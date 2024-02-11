using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalHouseApi.DTOs.Apartment;
using RentalHouseApi.Models;
using RentalHouseApi.Services;

namespace RentalHouseApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService _apartmentService;

    public ApartmentController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    [HttpGet]
    public ActionResult<ResponseDto<List<GetApartmentDto>>> GetAll()
    {
        return Ok(_apartmentService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<GetApartmentDto> GetById(Guid id)
    {
        return Ok(_apartmentService.GetById(id));
    }
    
    [HttpPost]
    public ActionResult<GetApartmentDto> Add(AddApartmentDtoRequest addApartmentDtoRequest)
    {
        return Ok(_apartmentService.Add(addApartmentDtoRequest));
    }

}