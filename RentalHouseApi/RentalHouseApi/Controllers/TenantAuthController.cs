using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentalHouseApi.DTOs.Tenant;
using RentalHouseApi.Services;

namespace RentalHouseApi.Controllers
{
    public class TenantAuthController : ControllerBase
    {

        private readonly ITenantAuthService _authService;

        public TenantAuthController(ITenantAuthService authService)
        {

            _authService = authService;

        }

        [HttpPost("Tenant/Login")]
        public async Task<ActionResult<ResponseDto<int>>> Login(TenantLoginDto request)
        {
            var response = await _authService.LoginForTenant(request.TcNo, request.PhoneNumber);
            if (response.Errors != null && response.Errors.Any())
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}