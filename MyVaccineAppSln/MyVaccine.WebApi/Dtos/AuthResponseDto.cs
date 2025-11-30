namespace MyVaccine.WebApi.Dtos;

public class AuthResponseDto
{
    public required string Token { get; set; }
    public DateTime Expiration { get; set; }
    public bool IsSuccess { get; set; }
    public string[]? Errors { get; set; }
}
