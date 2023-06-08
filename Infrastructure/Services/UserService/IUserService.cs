using Domain.Dtos;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    List<UserDto> GetUsers();
    UserDto GetUserByName(string name);
    UserDto GetUserById(int Id);
    UserDto AddUser(UserDto user);
    UserDto UpdateUser(UserDto user);
    bool DeleteUser(int Id);
}