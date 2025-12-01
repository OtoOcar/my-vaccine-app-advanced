using MyVaccine.WebApi.Models;

public interface IAllergyRepository
{
    Task<IEnumerable<Allergy>> GetAllAsync();
    Task<Allergy?> GetByIdAsync(int id);
    Task Add(Allergy entity);
    Task Update(Allergy entity);
    Task Delete(Allergy entity);
}