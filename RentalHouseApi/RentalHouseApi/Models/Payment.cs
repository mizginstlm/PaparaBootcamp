namespace RentalHouseApi.Models;
public class Payment
{
    public Guid Id { get; set; }
    public EPaymentType PaymentType { get; set; }
    public DateTime DateOfPayment { get; set; }
    public InvoiceType InvoiceType { get; set; }
    public decimal Amount { get; set; }
    public DateTime YearMonth { get; set; }
    public Guid TenantId { get; set; }
}