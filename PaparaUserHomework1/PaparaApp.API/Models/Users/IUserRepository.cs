namespace PaparaApp.API.Models.Users;

public interface IUserRepository
{
    List<User> GetAllUsers();
    User GetUserById(int id);
    List<User> AddUser(User user);
    User Update(User updatedUser);
    void DeleteUser(int id);
}