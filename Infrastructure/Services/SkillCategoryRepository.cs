using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SkillCategoryRepository(AppDbContext context) : ISkillCategoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(SkillCategory skillCategory)
        {
            await _context.SkillCategories.AddAsync(skillCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SkillCategory skillCategory)
        {
            _context.SkillCategories.Remove(skillCategory);
            await _context.SaveChangesAsync();
        }

        public IQueryable<SkillCategory> GetAll()
        {
            return _context.SkillCategories.Include(x => x.Skills).AsNoTracking();
        }

        public async Task<SkillCategory?> GetByIdAsync(long id)
        {
            return await _context.SkillCategories.Include(x => x.Skills)
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(SkillCategory skillCategory)
        {
            await _context.SaveChangesAsync();
        }
    }
}
