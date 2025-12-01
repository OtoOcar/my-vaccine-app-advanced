using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IVaccineService
    {
        Task<IEnumerable<VaccineResponseDto>> GetAll();
        Task<VaccineResponseDto?> GetById(int id);
        Task<VaccineResponseDto> Create(VaccineRequestDto request);
        Task<VaccineResponseDto?> Update(VaccineRequestDto request, int id);
        Task<bool> Delete(int id);
    }
}