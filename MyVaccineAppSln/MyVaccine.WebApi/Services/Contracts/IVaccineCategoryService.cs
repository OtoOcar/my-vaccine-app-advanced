using MyVaccine.WebApi.Dtos.VaccineCategory;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IVaccineCategoryService
    {
        Task<IEnumerable<VaccineCategoryResponseDto>> GetAll();
        Task<VaccineCategoryResponseDto?> GetById(int id);
        Task<VaccineCategoryResponseDto> Create(VaccineCategoryRequestDto request);
        Task<VaccineCategoryResponseDto?> Update(VaccineCategoryRequestDto request, int id);
        Task<bool> Delete(int id);
    }
}