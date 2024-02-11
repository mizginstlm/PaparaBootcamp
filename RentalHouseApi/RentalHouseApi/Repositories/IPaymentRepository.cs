
using RentalHouseApi.DTOs.Payment;
using RentalHouseApi.Models;

namespace RentalHouseApi.Repositories;

public interface IPaymentRepository
{
    List<Payment> GetAll();
    Payment Add(Payment payment);
    Payment? GetById(Guid id);
    void Update(Payment payment);
    void Delete(Guid id);
    Payment? GetByInvoiceTypeAndMonth(InvoiceType invoiceType, DateTime yearMonth, Guid? ApartmentId);



}