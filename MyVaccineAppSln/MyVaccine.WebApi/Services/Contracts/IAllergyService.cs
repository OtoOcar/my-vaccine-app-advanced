using MyVaccine.WebApi.Dtos.Allergy;

public interface IAllergyService
{
    Task<IEnumerable<AllergyResponseDto>> GetAll();
    Task<AllergyResponseDto?> GetById(int id);
    Task<AllergyResponseDto> Create(AllergyRequestDto request);
    Task<AllergyResponseDto?> Update(AllergyRequestDto request, int id);
    Task<bool> Delete(int id);
}