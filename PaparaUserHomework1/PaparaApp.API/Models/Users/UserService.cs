using AutoMapper;
using DTOs;
using PaparaApp.API.DTOs;

namespace PaparaApp.API.Models.Users;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper)
    {
        _mapper = mapper;
        userRepository = new UserRepository();
    }


    public ResponseService<AddUserDto> AddUser(AddUserDto addedUser)
    {
        var responseService = new ResponseService<AddUserDto>();
        var addedUserData = _mapper.Map<User>(addedUser);
        userRepository.AddUser(_mapper.Map<User>(addedUserData));
        responseService.Data = _mapper.Map<AddUserDto>(addedUserData);
        return responseService;
    }

    public void DeleteUser(int id)
    {
        userRepository.DeleteUser(id);
    }

    public ResponseService<List<GetUserDto>> GetAllUsers(string? name, int? age = null)
    {
        var responseService = new ResponseService<List<GetUserDto>>();
        List<User> Users = userRepository.GetAllUsers();
        responseService.Data = Users.Where(x => name == null || x.UserName == name)
            .Where(x => age == null || x.UserAge == age).Select(c => _mapper.Map<GetUserDto>(c)).ToList();

        return responseService;
    }

    public ResponseService<GetUserDto> GetUserById(int id)
    {
        var responseService = new ResponseService<GetUserDto>();
        var user = userRepository.GetUserById(id);
        responseService.Data = _mapper.Map<GetUserDto>(user);
        return responseService;
    }

    public void Update(UpdateUserDto updatedUser)
    {
        var updatedUserData = _mapper.Map<User>(updatedUser);
        userRepository.Update(updatedUserData);
    }
}