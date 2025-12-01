using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IVaccineRepository
    {
        Task<IEnumerable<Vaccine>> GetAllAsync();
        Task<Vaccine?> GetByIdAsync(int id);
        Task Add(Vaccine entity, List<int> categoryIds);
        Task Update(Vaccine entity, List<int> categoryIds);
        Task Delete(Vaccine entity);
    }
}