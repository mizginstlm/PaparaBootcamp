using RentalHouseApi.DTOs.Payment;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Models;

namespace RentalHouseApi.Services
{
    public interface IPaymentService
    {
        ResponseDto<List<GetPaymentDto>> GetAll();
        ResponseDto<GetPaymentDto> GetById(Guid id);
        void Delete(Guid id);
        ResponseDto<Guid> Add(AddPaymentDtoRequest request);
        void Update(AddPaymentDtoRequest request, Guid id);
        ResponseDto<List<Guid>> AddMultiple(List<AddPaymentDtoRequest> requests);
        Task<ResponseDto<GetPaymentDto>> MakePayment(TenantPaymentDto newPayment);


    }
}