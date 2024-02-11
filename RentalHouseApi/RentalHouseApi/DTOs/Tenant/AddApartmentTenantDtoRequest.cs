using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHouseApi.DTOs.Apartment
{
    public class MatchApartmentTenantDtoRequest
    {
        public Guid ApartmentId { get; set; } = default!;
        public Guid TenantId { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime? EndDate { get; set; }
    }
}