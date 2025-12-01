using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.FamilyGroup;

namespace MyVaccine.WebApi.Dtos.User;

public class UserDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public List<DependentDto> Dependents { get; set; } = new();
    public List<AllergyResponseDto> Allergies { get; set; } = new();
    public FamilyGroupResponseDto? FamilyGroup { get; set; } = new();
}

public class DependentDto
{
    public int DependentId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}