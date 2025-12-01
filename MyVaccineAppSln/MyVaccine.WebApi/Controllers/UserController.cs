using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Auth;
using MyVaccine.WebApi.Dtos.User;
using MyVaccine.WebApi.Services.Contracts;
using System.Security.Claims;

namespace MyVaccine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(UserManager<IdentityUser> userManager, IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequetDto request)
    {
        var response = await _userService.Register(request);

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response);
        }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
    {
        var response = await _userService.Login(model);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return Unauthorized(response);
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _userService.GetAll();
        return Ok(response);
    }


    [Authorize]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        var response = await _userService.RefreshToken(claimsIdentity.Name);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return Unauthorized(response);
        }
    }

    [Authorize]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        var response = await _userService.GetUserInfo(claimsIdentity.Name);

        return Ok(response);
    }


    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequestDto request)
    {
        if (request == null || id <= 0)
            return BadRequest(new { message = "Datos inválidos" });

        var response = await _userService.Update(request, id);

        if (response == null)
            return NotFound(new { message = "Usuario no encontrado" });

        return Ok(response);
    }



    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (id <= 0)
            return BadRequest(new { message = "Id inválido" });

        var deleted = await _userService.Delete(id);

        if (deleted==null)
            return NotFound(new { message = "Usuario no encontrado" });

        return Ok(new { message = "Usuario eliminado correctamente" });
    }



}




