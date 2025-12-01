using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineCategoryRepository : IVaccineCategoryRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public VaccineCategoryRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaccineCategory>> GetAllAsync()
        {
            return await _context.VaccineCategories.ToListAsync();
        }

        public async Task<VaccineCategory?> GetByIdAsync(int id)
        {
            return await _context.VaccineCategories.FirstOrDefaultAsync(vc => vc.VaccineCategoryId == id);
        }

        public async Task Add(VaccineCategory entity)
        {
            _context.VaccineCategories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(VaccineCategory entity)
        {
            _context.VaccineCategories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(VaccineCategory entity)
        {
            _context.VaccineCategories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}