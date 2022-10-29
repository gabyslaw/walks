using Microsoft.EntityFrameworkCore;
using walks.Data;
using walks.Models.Domain;

namespace walks.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly WalksDbContext _context;

        public WalkDifficultyRepository(WalksDbContext context)
        {
            _context = context;
        }


        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await _context.WalkDifficulty.AddAsync(walkDifficulty);
            await _context.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await _context.WalkDifficulty.FindAsync(id);
            if (existingWalkDifficulty != null)
            {
                _context.WalkDifficulty.Remove(existingWalkDifficulty);
                await _context.SaveChangesAsync();
                return existingWalkDifficulty;
            }
            return null;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _context.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await _context.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await _context.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;
            await _context.SaveChangesAsync();
            return existingWalkDifficulty;
        }
    }
}
