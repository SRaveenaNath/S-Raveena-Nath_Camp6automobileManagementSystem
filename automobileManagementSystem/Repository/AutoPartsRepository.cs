using automobileManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace automobileManagementSystem.Repository
{
    public class AutoPartsRepository : IAutoPartsRepository
    {
        private readonly AutomobileManagementDbContext _context;

        public AutoPartsRepository(AutomobileManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AutoPart>> GetAllPartsAsync()
        {
            return await _context.AutoParts.Include(p => p.CompatibleCarModels).ToListAsync();
        }

        public async Task<AutoPart> GetPartByIdAsync(int id)
        {
            return await _context.AutoParts.Include(p => p.CompatibleCarModels)
                                           .FirstOrDefaultAsync(p => p.PartId == id);
        }

        public async Task<AutoPart> AddPartAsync(AutoPart autoPart)
        {
            _context.AutoParts.Add(autoPart);
            await _context.SaveChangesAsync();
            return autoPart; // Return the created part
        }

        public async Task<AutoPart> UpdatePartAsync(AutoPart autoPart)
        {
            _context.AutoParts.Update(autoPart);
            await _context.SaveChangesAsync();
            return autoPart; // Return the updated part
        }


        public async Task<bool> DeletePartAsync(int id)
        {
            var part = await _context.AutoParts.FindAsync(id);
            if (part != null)
            {
                _context.AutoParts.Remove(part);
                await _context.SaveChangesAsync();
                return true; // Indicate that the part was successfully deleted
            }
            return false; // Indicate that the part was not found
        }

    }
}
