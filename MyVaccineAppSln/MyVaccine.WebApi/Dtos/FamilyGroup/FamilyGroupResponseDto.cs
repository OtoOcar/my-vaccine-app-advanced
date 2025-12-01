using MyVaccine.WebApi.Dtos.User;

namespace MyVaccine.WebApi.Dtos.FamilyGroup
{
    public class FamilyGroupResponseDto
    {
        public int FamilyGroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserDto> Users { get; set; } = new();
    }
}