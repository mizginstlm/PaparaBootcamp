
using Microsoft.AspNetCore.Mvc;
using RentalHouseApi.DTOs.Manager;
using RentalHouseApi.Services;

namespace RentalHouseApi.Controllers
{
    public class ManagerAuthController : ControllerBase
    {

        private readonly IManagerAuthService _authService;

        public ManagerAuthController(IManagerAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseDto<int>>> Login(ManagerDto request)
        {
            var response = await _authService.LoginForManager(request.ManagerName, request.Password);
            if (response.Errors != null && response.Errors.Any())
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}