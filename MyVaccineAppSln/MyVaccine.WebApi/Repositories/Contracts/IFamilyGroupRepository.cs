using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IFamilyGroupRepository
    {
        Task<IEnumerable<FamilyGroup>> GetAllAsync();
        Task<FamilyGroup?> GetByIdAsync(int id);
        Task Add(FamilyGroup entity);
        Task Update(FamilyGroup entity);
        Task Delete(FamilyGroup entity);
    }
}