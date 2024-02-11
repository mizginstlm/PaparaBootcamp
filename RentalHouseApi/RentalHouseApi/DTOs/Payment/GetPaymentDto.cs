using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalHouseApi.Models;

namespace RentalHouseApi.DTOs.Payment
{
    public class GetPaymentDto
    {
        public Guid Id { get; set; }
        public EPaymentType PaymentType { get; set; }

        public DateTime DateOfPayment { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public decimal Amount { get; set; }

        public DateTime YearMonth { get; set; }

        public Guid ApartmentId { get; set; }

    }
}