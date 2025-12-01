using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class FamilyGroupRepository : IFamilyGroupRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public FamilyGroupRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FamilyGroup>> GetAllAsync()
        {
            return await _context.FamilyGroups
                .Include(fg => fg.Users)
                .ToListAsync();
        }

        public async Task<FamilyGroup?> GetByIdAsync(int id)
        {
            return await _context.FamilyGroups
                .Include(fg => fg.Users)
                .FirstOrDefaultAsync(fg => fg.FamilyGroupId == id);
        }

        public async Task Add(FamilyGroup entity)
        {
            _context.FamilyGroups.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(FamilyGroup entity)
        {
            _context.FamilyGroups.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(FamilyGroup entity)
        {
            _context.FamilyGroups.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}