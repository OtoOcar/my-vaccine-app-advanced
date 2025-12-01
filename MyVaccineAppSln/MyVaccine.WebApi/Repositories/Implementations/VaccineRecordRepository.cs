using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineRecordRepository : IVaccineRecordRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public VaccineRecordRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaccineRecord>> GetAllAsync()
        {
            return await _context.VaccineRecords
                .Include(vr => vr.User)
                .Include(vr => vr.Dependent)
                .Include(vr => vr.Vaccine)
                    .ThenInclude(v => v.Categories)
                .ToListAsync();
        }

        public async Task<VaccineRecord?> GetByIdAsync(int id)
        {
            return await _context.VaccineRecords
                .Include(vr => vr.User)
                .Include(vr => vr.Dependent)
                .Include(vr => vr.Vaccine)
                    .ThenInclude(v => v.Categories)
                .FirstOrDefaultAsync(vr => vr.VaccineRecordId == id);
        }

        public async Task Add(VaccineRecord entity)
        {
            _context.VaccineRecords.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(VaccineRecord entity)
        {
            _context.VaccineRecords.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(VaccineRecord entity)
        {
            _context.VaccineRecords.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}