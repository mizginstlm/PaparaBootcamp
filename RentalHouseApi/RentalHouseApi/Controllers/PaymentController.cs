using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalHouseApi.DTOs.Payment;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Services;
namespace RentalHouseApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }


    [HttpGet]
    public ActionResult<ResponseDto<List<GetPaymentDto>>> GetAll()
    {
        return Ok(_paymentService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<GetPaymentDto> GetById(Guid id)
    {
        return Ok(_paymentService.GetById(id));
    }

    [HttpPost]
    public ActionResult<ResponseDto<GetPaymentDto>> Add(AddPaymentDtoRequest newPayment)
    {
        return Ok(_paymentService.Add(newPayment));
    }

    [HttpPost("AddMultiple")]
    public ActionResult<ResponseDto<List<Guid>>> AddMultiple(List<AddPaymentDtoRequest> newPayments)
    {
        return Ok(_paymentService.AddMultiple(newPayments));
    }

    [HttpPut]
    public ActionResult<ResponseDto<GetPaymentDto>> Update(AddPaymentDtoRequest updatedPayment, Guid id)
    {
        _paymentService.Update(updatedPayment, id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<ResponseDto<GetPaymentDto>> Delete(Guid id)
    {
        _paymentService.Delete(id);
        return NoContent();
    }


    [Authorize]
    [HttpPost("MakePayment")]
    public async Task<ActionResult<ResponseDto<GetPaymentDto>>> MakePayment(TenantPaymentDto newPayment)
    {
        return await _paymentService.MakePayment(newPayment);
    }
}