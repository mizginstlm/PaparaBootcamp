using System.Security.Claims;
using AutoMapper;
using RentalHouseApi.Data;
using RentalHouseApi.DTOs.Payment;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Repositories;
using RentalHouseApi.UnitOfWorks;

namespace RentalHouseApi.Services;

public class PaymentSqlService : IPaymentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantRepository _tenantRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPaymentRepository _paymentRepository;

    private string GetUserId() => _httpContextAccessor.HttpContext!.User
          .FindFirstValue(ClaimTypes.NameIdentifier)!;

    public PaymentSqlService(IPaymentRepository paymentRepository, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ITenantRepository tenantRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _paymentRepository = paymentRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _tenantRepository = tenantRepository;
    }

    public ResponseDto<Guid> Add(AddPaymentDtoRequest request)
    {
        var payment = _mapper.Map<Payment>(request);
        var existingPayment = _paymentRepository.GetByInvoiceTypeAndMonth(request.InvoiceType, request.YearMonth, request.TenantId);

        if (existingPayment != null)
        {
            return ResponseDto<Guid>.Fail("Payment already exists for this month");
        }

        _paymentRepository.Add(payment!);
        _unitOfWork.Commit();
        return new ResponseDto<Guid> { Data = payment!.Id };
    }

    public void Delete(Guid id)
    {
        _paymentRepository.Delete(id);
        _unitOfWork.Commit();
    }

    public ResponseDto<List<GetPaymentDto>> GetAll()
    {
        var payments = _paymentRepository.GetAll();
        var paymentsDto = _mapper.Map<List<GetPaymentDto>>(payments);
        return new ResponseDto<List<GetPaymentDto>> { Data = paymentsDto };
    }

    public ResponseDto<GetPaymentDto> GetById(Guid id)
    {
        var payment = _paymentRepository.GetById(id);
        var paymentDto = _mapper.Map<GetPaymentDto>(payment);
        return new ResponseDto<GetPaymentDto> { Data = paymentDto };
    }

    public void Update(AddPaymentDtoRequest request, Guid id)
    {
        var payment = _paymentRepository.GetById(id);
        if (payment != null)
        {
            payment.Amount = request.Amount;
            payment.InvoiceType = request.InvoiceType;
            payment.TenantId = request.TenantId;
            payment.YearMonth = request.YearMonth;
        }
        _paymentRepository.Update(payment!);
        _unitOfWork.Commit();
    }

    public ResponseDto<List<Guid>> AddMultiple(List<AddPaymentDtoRequest> requests)
    {
        List<Guid> addedPaymentIds = new List<Guid>();

        foreach (var request in requests)
        {
            var existingPayment = _paymentRepository.GetByInvoiceTypeAndMonth(request.InvoiceType, request.YearMonth, request.TenantId);
            if (existingPayment != null)
            {
                return ResponseDto<List<Guid>>.Fail("Payment already exists for some of these months");
            }
            var payment = _mapper.Map<Payment>(request);
            _paymentRepository.Add(payment!);
            addedPaymentIds.Add(payment!.Id);
        }

        _unitOfWork.Commit();

        return new ResponseDto<List<Guid>> { Data = addedPaymentIds };
    }

    public async Task<ResponseDto<GetPaymentDto>> MakePayment(TenantPaymentDto newTenantPayment)
    {
        string userIdString = GetUserId();
        var tenant = await _tenantRepository.GetTenantForPayment(userIdString, newTenantPayment);
        if (tenant is null)
        {
            return ResponseDto<GetPaymentDto>.Fail("Tenant not found");
        }
        var payment = _paymentRepository.GetById(newTenantPayment.PaymentId);

        if (payment is null)
        {
            return ResponseDto<GetPaymentDto>.Fail("Payment not found");
        }
        payment!.DateOfPayment = newTenantPayment.DateOfPayment;
        tenant.Payments.Add(payment);
        await _unitOfWork.CommitAsync();
        return ResponseDto<GetPaymentDto>.Success(_mapper.Map<GetPaymentDto>(payment)!);
    }
}