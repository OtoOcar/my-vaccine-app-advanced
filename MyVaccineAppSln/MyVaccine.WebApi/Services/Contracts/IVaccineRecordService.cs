using MyVaccine.WebApi.Dtos.VaccineRecord;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IVaccineRecordService
    {
        Task<IEnumerable<VaccineRecordResponseDto>> GetAll();
        Task<VaccineRecordResponseDto?> GetById(int id);
        Task<VaccineRecordResponseDto> Create(VaccineRecordRequestDto request);
        Task<VaccineRecordResponseDto?> Update(VaccineRecordRequestDto request, int id);
        Task<bool> Delete(int id);
    }
}