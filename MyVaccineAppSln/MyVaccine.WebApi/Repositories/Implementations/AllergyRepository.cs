using MyVaccine.WebApi.Models;
using Microsoft.EntityFrameworkCore;

public class AllergyRepository : IAllergyRepository
{
    private readonly MyVaccineAppDbContext _context;

    public AllergyRepository(MyVaccineAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Allergy>> GetAllAsync()
    {
        return await _context.Allergies.ToListAsync();
    }

    public async Task<Allergy?> GetByIdAsync(int id)
    {
        return await _context.Allergies.FirstOrDefaultAsync(a => a.AllergyId == id);
    }

    public async Task Add(Allergy entity)
    {
        _context.Allergies.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Allergy entity)
    {
        _context.Allergies.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Allergy entity)
    {
        _context.Allergies.Remove(entity);
        await _context.SaveChangesAsync();
    }
}