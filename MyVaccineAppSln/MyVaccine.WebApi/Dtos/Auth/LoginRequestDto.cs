namespace MyVaccine.WebApi.Dtos.Auth;

public class LoginRequestDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
