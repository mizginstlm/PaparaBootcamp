using DTOs;
using PaparaApp.API.DTOs;

namespace PaparaApp.API.Models.Users;

public interface IUserService
{
    ResponseService<List<GetUserDto>> GetAllUsers(string? name, int? age = null);
    ResponseService<GetUserDto> GetUserById(int id);
    ResponseService<AddUserDto> AddUser(AddUserDto addedUser);
    void Update(UpdateUserDto updatedUser);
    void DeleteUser(int id);
}