using Microsoft.AspNetCore.Mvc;
using RentalHouseApi.DTOs;
using RentalHouseApi.DTOs.Apartment;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Services;

namespace RentalHouseApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TenantController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public TenantController(ITenantService tenantService, ITenantAuthService authService)
    {
        _tenantService = tenantService;

    }

    [HttpGet]
    public ActionResult<ResponseDto<List<GetTenantDto>>> GetAll()
    {
        return Ok(_tenantService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<GetTenantDto> GetById(Guid id)
    {
        return Ok(_tenantService.GetById(id));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        _tenantService.Delete(id);
        return Ok();
    }

    [HttpPost]
    public ActionResult<ResponseDto<Guid>> Add(AddTenantDtoRequest request)
    {
        if (ModelState.IsValid == false)
            return BadRequest(ModelState);

        return Ok(_tenantService.Add(request));

    }

    [HttpPut]
    public ActionResult Update(AddTenantDtoRequest request, Guid id)
    {
        if (ModelState.IsValid == false)
            return BadRequest(ModelState);
        _tenantService.Update(request, id);
        return Ok();
    }


    [HttpPost("MatchTenantToApartment")]
    public ActionResult MatchTenantToApartment(MatchApartmentTenantDtoRequest request)
    {
        _tenantService.MatchTenantToApartment(request);
        return Ok();
    }


}