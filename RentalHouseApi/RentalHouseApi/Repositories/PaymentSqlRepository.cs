using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalHouseApi.Data;
using RentalHouseApi.Models;
using RentalHouseApi.UnitOfWorks;

namespace RentalHouseApi.Repositories
{


    public class PaymentSqlRepository : IPaymentRepository
    {
        private readonly DatabaseContext _context;

        public PaymentSqlRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Payment Add(Payment payment)
        {
            _context.Payments.Add(payment);

            return payment;
        }
        public void Delete(Guid id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);

            }
        }

        public List<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }

        public Payment? GetById(Guid id)
        {
            return _context.Payments.Find(id);
        }

        public Payment? GetByInvoiceTypeAndMonth(InvoiceType invoiceType, DateTime yearMonth, Guid? TenantId)
        {
            return _context.Payments
                         .FirstOrDefault(p => p.InvoiceType == invoiceType && p.YearMonth == yearMonth && p.TenantId == TenantId);

        }

        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);

        }




    }
}