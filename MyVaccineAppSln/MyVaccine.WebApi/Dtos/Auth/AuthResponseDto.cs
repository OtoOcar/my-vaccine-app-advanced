namespace MyVaccine.WebApi.Dtos.Auth;

public class AuthResponseDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public bool IsSuccess { get; set; }
    public string[]? Errors { get; set; }
    public string Message { get; set; }
}
