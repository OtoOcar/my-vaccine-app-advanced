using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public VaccineRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vaccine>> GetAllAsync()
        {
            return await _context.Vaccines
                .Include(v => v.Categories) // trae las categorías
                .ToListAsync();
        }

        public async Task<Vaccine?> GetByIdAsync(int id)
        {
            return await _context.Vaccines
                .Include(v => v.Categories) // trae las categorías
                .FirstOrDefaultAsync(v => v.VaccineId == id);
        }


        public async Task Add(Vaccine entity, List<int> categoryIds)
        {
            entity.Categories = await _context.VaccineCategories
                .Where(vc => categoryIds.Contains(vc.VaccineCategoryId))
                .ToListAsync();

            _context.Vaccines.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vaccine entity, List<int> categoryIds)
        {
            entity.Categories = await _context.VaccineCategories
                .Where(vc => categoryIds.Contains(vc.VaccineCategoryId))
                .ToListAsync();

            _context.Vaccines.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Vaccine entity)
        {
            _context.Vaccines.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}