using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalHouseApi.Models;

namespace RentalHouseApi.DTOs.Payment
{
    public class AddPaymentDtoRequest
    {
        [EnumDataType(typeof(InvoiceType), ErrorMessage = "Invalid invoice type.")]
        public InvoiceType InvoiceType { get; set; } = default!;

        [Range(0, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; } = default!;
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime YearMonth { get; set; } = default!;
        public Guid TenantId { get; set; } = default!;
    }
}