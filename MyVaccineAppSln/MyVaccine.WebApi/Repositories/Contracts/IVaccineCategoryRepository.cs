using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IVaccineCategoryRepository
    {
        Task<IEnumerable<VaccineCategory>> GetAllAsync();
        Task<VaccineCategory?> GetByIdAsync(int id);
        Task Add(VaccineCategory entity);
        Task Update(VaccineCategory entity);
        Task Delete(VaccineCategory entity);
    }
}