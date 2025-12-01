using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.WebApi.Dtos.Auth;
using MyVaccine.WebApi.Dtos.User;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyVaccine.WebApi.Services.Implementations;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, UserManager<IdentityUser> userManager, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userManager = userManager;
        _userRepository = userRepository;
    }

    public async Task<AuthResponseDto> Register(RegisterRequetDto request)
    {
        var identityUser = new IdentityUser
        {
            UserName = request.Username,
            Email = request.Email   // <-- guardar email en AspNetUser
        };

        var result = await _userManager.CreateAsync(identityUser, request.Password);

        if (!result.Succeeded)
        {
            return new AuthResponseDto
            {
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description).ToArray()

            };
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            AspNetUserId = identityUser.Id
        };

        await _userRepository.AddAsync(user);

        return new AuthResponseDto
        {
            IsSuccess = true,
            Message = "Usuario registrado correctamente"
        };
    }

    public async Task<AuthResponseDto> Login(LoginRequestDto request)
    {
        var response = new AuthResponseDto();
        try
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(MyVaccineLiterals.JWT_KEY)));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    //issuer: _configuration["JwtIssuer"],
                    //audience: _configuration["JwtAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: creds
                );

                var tokenresult = new JwtSecurityTokenHandler().WriteToken(token);
                response.Token = tokenresult;
                response.Expiration = token.ValidTo;
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Errors = new string[] { ex.Message };
        }

        return response;

    }
    public async Task<AuthResponseDto> RefreshToken(string email)
    {
        var response = new AuthResponseDto();
        try
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(MyVaccineLiterals.JWT_KEY)));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    //issuer: _configuration["JwtIssuer"],
                    //audience: _configuration["JwtAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: creds
                );

                var tokenresult = new JwtSecurityTokenHandler().WriteToken(token);
                response.Token = tokenresult;
                response.Expiration = token.ValidTo;
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Errors = new string[] { ex.Message };
        }

        return response;

    }

    public async Task<UserDto?> GetUserInfo(string username)
    {
        // Busca por username
        var identityUser = await _userManager.FindByNameAsync(username);
        if (identityUser == null) return null;

        var entity = await _userRepository
            .FindByAsNoTracking(x => x.AspNetUserId == identityUser.Id)
            .Include(x => x.Dependents)
            .Include(u => u.Allergies)
            .Include(u => u.FamilyGroups)
            .FirstOrDefaultAsync();

        if (entity == null) return null;

        var dto = _mapper.Map<UserDto>(entity);
        dto.Email = identityUser.Email; // Email directo desde Identity

        return dto;
    }



    public async Task<UserResponseDto?> Update(UserRequestDto request, int id)
    {
        var entity = await _userRepository
            .FindBy(x => x.UserId == id)
            .FirstOrDefaultAsync();

        if (entity == null) return null;

        // Actualiza los campos
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        //entity.Email = request.Email;

        await _userRepository.Update(entity);

        return _mapper.Map<UserResponseDto>(entity);
    }


    public async Task<IEnumerable<UserResponseDto>> GetAll()
    {
        var entities = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserResponseDto>>(entities);
    }

    public async Task<UserResponseDto?> Delete(int id)
    {
        var entity = await _userRepository.GetByIdAsync(id);
        if (entity == null) return null;

        await _userRepository.Delete(entity);
        return _mapper.Map<UserResponseDto>(entity);
    }

}


