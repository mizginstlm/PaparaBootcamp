using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalHouseApi.DTOs.Manager
{
    public class ManagerDto
    {

        [Required(ErrorMessage = "Must have a name.")][StringLength(50, ErrorMessage = "PLease write with a valid length.")] public string ManagerName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Must have a name.")][StringLength(50, MinimumLength = 8, ErrorMessage = "PLease write with a valid length.")] public string Password { get; set; } = string.Empty;
    }
}