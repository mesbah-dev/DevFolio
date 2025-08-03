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
            skillCategory.Deleted = true;
            await _context.SaveChangesAsync();
        }

        public IQueryable<SkillCategory> GetAll()
        {
            return _context.SkillCategories
                .Include(x => x.Skills)
                .Where(s => !s.Deleted)
                .AsNoTracking();
        }

        public async Task<SkillCategory?> GetByIdAsync(long id)
        {
            return await _context.SkillCategories
                                 .Where(s => !s.Deleted && s.Id == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<SkillCategory?> GetByIdWithSkillsAsync(long id)
        {
            return await _context.SkillCategories
                .Include(x => x.Skills)
                .Where(s => !s.Deleted && s.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
