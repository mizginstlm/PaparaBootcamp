using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHouseApi.DTOs.Tenant
{
    public class TenantLoginDto
    {

        [Required(ErrorMessage = "TC Kimlik Numarası boş bırakılamaz")]
        [MinLength(11, ErrorMessage = "TC Kimlik Numarası 11 karakter olmalıdır")]
        public string TcNo { get; set; } = default!;



        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Telefon Numarası 10 karakter olmalıdır")]
        public string PhoneNumber { get; set; } = default!;
    }
}