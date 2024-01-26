namespace PaparaApp.API.Models.Users;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string UserSurname { get; set; } = null!;
    public int UserAge { get; set; }
}