namespace MyVaccine.WebApi.Dtos;

public class RegisterRequetDto
{
    public required string Username { get; set; }
    //public string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
