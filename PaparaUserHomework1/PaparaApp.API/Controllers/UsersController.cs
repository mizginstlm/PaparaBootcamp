using Microsoft.AspNetCore.Mvc;
using PaparaApp.API.DTOs;
using PaparaApp.API.Models;
using PaparaApp.API.Models.Users;

namespace PaparaApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // [HttpGet]
    // public IActionResult GetAll()
    // {
    //     // Object to Json = Serialiation
    //     // Json to Object = Deserialiation
    //     // return new OkObjectResult("all users");
    //     return Ok(userService.GetAll());
    // }

    [HttpGet]
    public ActionResult<ResponseService<List<User>>> Get(string? name, int? age = null)
    {
        return Ok(_userService.GetAllUsers(name, age));
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetSingle(int id)
    {
        return Ok(_userService.GetUserById(id));
    }

    [HttpPost]
    public ActionResult<User> AddUser(AddUserDto newUser)
    {
        return Ok(_userService.AddUser(newUser));
    }

    [HttpPut]
    public void UpdateUser(UpdateUserDto updatedUser)
    {
        _userService.Update(updatedUser);
    }

    [HttpDelete]
    public void DeleteUser(int id)
    {
        _userService.DeleteUser(id);
    }

}