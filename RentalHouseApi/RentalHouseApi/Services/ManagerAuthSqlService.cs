using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RentalHouseApi.Repositories;
namespace RentalHouseApi.Services;

public class ManagerAuthSqlService : IManagerAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IAuthManagerRepository _managerAuthRepository;

    public ManagerAuthSqlService(IConfiguration configuration, IAuthManagerRepository managerAuthRepository)
    {
        _configuration = configuration;
        _managerAuthRepository = managerAuthRepository;
    }


    public async Task<ResponseDto<string>> LoginForManager(string managerName, string password)
    {
        var response = new ResponseDto<string>();
        var manager = await _managerAuthRepository.GetByNameAsync(managerName);
        if (manager is null) ResponseDto<String>.Fail("Managername or password is wrong!");
        else if (!VerifyPasswordHash(password, manager.PasswordHash, manager.PasswordSalt)) ResponseDto<String>.Fail("Managername or password is wrong!");
        else
        {
            response.Data = CreateToken(manager);
        }
        return response;
    }

    private string CreateToken(Manager manager)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, manager.Id.ToString())
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


    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);//SequenceEqual is a method used to compare two sequences (e.g., arrays or lists) .
        }
    }


}
