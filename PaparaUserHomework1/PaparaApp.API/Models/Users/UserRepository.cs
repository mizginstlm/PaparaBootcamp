using PaparaApp.API.DTOs;

namespace PaparaApp.API.Models.Users;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public UserRepository()
    {
        if (Users.Count == 0)
        {
            Users.Add(new User { Id = 1, UserName = "User1", UserSurname = "Surname1", UserAge = 23 });
            Users.Add(new User { Id = 2, UserName = "User2", UserSurname = "Surname2", UserAge = 24 });
            Users.Add(new User { Id = 3, UserName = "User3", UserSurname = "Surname3", UserAge = 40 });
            Users.Add(new User { Id = 4, UserName = "User4", UserSurname = "Surname4", UserAge = 36 });
        }
    }


    public List<User> GetAllUsers()
    {
        return Users;
    }


    public User GetUserById(int id)
    {
        var user = Users.FirstOrDefault(c => c.Id == id);
        if (user is not null)
            return user;

        throw new Exception($"User with ID {id} not found");

    }

    public List<User> AddUser(User user)
    {
        Users.Add(user);
        return Users;
    }


    public User Update(User updatedUser)
    {
        var user = Users.FirstOrDefault(c => c.Id == updatedUser.Id) ?? throw new Exception($"Character with Id '{updatedUser.Id}' not found.");

        user.UserName = updatedUser.UserName;
        user.UserSurname = updatedUser.UserSurname;
        user.UserAge = updatedUser.UserAge;

        return updatedUser;
    }

    public void DeleteUser(int id)
    {
        var userToDeleteIndex = Users.FindIndex(p => p.Id == id);
        Users.RemoveAt(userToDeleteIndex);
    }
}