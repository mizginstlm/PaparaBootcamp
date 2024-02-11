using Microsoft.AspNetCore.Identity;

namespace RentalHouseApi.Services
{
    public class IdentityService
    {
        public RoleManager<AppRole> RoleManager { get; set; }
        public UserManager<AppUser> UserManager { get; set; }

        // Default constructor

        public IdentityService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }


        // Setter for RoleManager


        public async Task<ResponseDto<string>> CreateRole(RoleCreateRequestDto request)
        {
            var appRole = new AppRole
            {
                Name = request.RoleName
            };



            IdentityResult? roleCreateResult = null;
            roleCreateResult = await RoleManager.CreateAsync(appRole);
            if (roleCreateResult is not null && !roleCreateResult.Succeeded)
            {
                var errorList = roleCreateResult.Errors.Select(x => x.Description).ToList();

                return ResponseDto<string>.Fail(errorList);
            }


            var hasUser = await UserManager.FindByIdAsync(request.UserId);

            if (hasUser is null)
            {
                return ResponseDto<string>.Fail("kullanıcı bulunamadı.");
            }


            var roleAssignResult = await UserManager.AddToRoleAsync(hasUser, appRole.Name);

            if (!roleAssignResult.Succeeded)
            {
                var errorList = roleAssignResult.Errors.Select(x => x.Description).ToList();

                return ResponseDto<string>.Fail(errorList);
            }

            return ResponseDto<string>.Success(string.Empty);
        }
    }
}