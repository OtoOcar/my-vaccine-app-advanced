using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IVaccineRecordRepository
    {
        Task<IEnumerable<VaccineRecord>> GetAllAsync();
        Task<VaccineRecord?> GetByIdAsync(int id);
        Task Add(VaccineRecord entity);
        Task Update(VaccineRecord entity);
        Task Delete(VaccineRecord entity);
    }
}