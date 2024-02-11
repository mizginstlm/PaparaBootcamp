using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RentalHouseApi.Repositories;
namespace RentalHouseApi.Services;
public class TenantAuthSqlService : ITenantAuthService
{
    private readonly IConfiguration _configuration;
    private readonly ITenantAuthRepository _tenantAuthRepository;
    public TenantAuthSqlService(IConfiguration configuration, ITenantAuthRepository tenantAuthRepository)
    {
        _configuration = configuration;
        _tenantAuthRepository = tenantAuthRepository;
    }

    public async Task<ResponseDto<string>> LoginForTenant(string TcNo, string PhoneNumber)
    {
        var response = new ResponseDto<string>();
        var tenant = await _tenantAuthRepository.GetByNameAsync(TcNo);
        if (tenant is null) ResponseDto<String>.Fail("TcNo or PhoneNumber is wrong!");
        else if (!tenant.PhoneNumber.Equals(PhoneNumber)) ResponseDto<String>.Fail("TcNo or PhoneNumber is wrong!");
        else
        {
            response.Data = CreateToken(tenant);
        }
        return response;
    }

    private string CreateToken(Tenant tenant)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, tenant.Id.ToString()),
        };

        var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
        if (appSettingsToken is null)
            throw new Exception("AppSettings Token is null!");

        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(appSettingsToken));

        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
