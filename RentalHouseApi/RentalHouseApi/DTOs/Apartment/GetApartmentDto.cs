using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalHouseApi.Models;

namespace RentalHouseApi.DTOs.Apartment
{
    public class GetApartmentDto
    {
        public Guid Id { get; set; }
        public bool IsEmpty { get; set; }
        public EApartmentType Class { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; } = default!;
    }
}