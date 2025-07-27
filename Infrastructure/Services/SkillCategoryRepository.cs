using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<SkillCategory>> GetAllAsync()
        {
            return await _context.SkillCategories.Include(x => x.Skills).ToListAsync();
        }

        public async Task<SkillCategory?> GetByIdAsync(long id)
        {
            return await _context.SkillCategories.Include(x => x.Skills)
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(SkillCategory skillCategory)
        {
            _context.SkillCategories.Update(skillCategory);
            await _context.SaveChangesAsync();
        }
    }
}
