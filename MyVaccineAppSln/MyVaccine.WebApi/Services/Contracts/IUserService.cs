using MyVaccine.WebApi.Dtos.Auth;
using MyVaccine.WebApi.Dtos.User;

namespace MyVaccine.WebApi.Services.Contracts;

public interface IUserService
{
    Task<AuthResponseDto> Register(RegisterRequetDto request);
    //Task<AuthResponseDto> AddUserAsync(RegisterRequetDto request);
    Task<AuthResponseDto> Login(LoginRequestDto request);
    Task<AuthResponseDto> RefreshToken(string email);
    Task<UserDto> GetUserInfo(string email);
    Task<UserResponseDto?> Update(UserRequestDto request, int id);
    Task<IEnumerable<UserResponseDto>> GetAll();
    Task<UserResponseDto?> Delete(int id);

}
