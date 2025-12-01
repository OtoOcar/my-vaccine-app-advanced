using MyVaccine.WebApi.Dtos.FamilyGroup;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IFamilyGroupService
    {
        Task<IEnumerable<FamilyGroupResponseDto>> GetAll();
        Task<FamilyGroupResponseDto?> GetById(int id);
        Task<FamilyGroupResponseDto> Create(FamilyGroupRequestDto request);
        Task<FamilyGroupResponseDto?> Update(FamilyGroupRequestDto request, int id);
        Task<bool> Delete(int id);
    }
}