using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SkillRepository(AppDbContext context) : ISkillRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Skill skill)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Skill> GetAll()
        {
            return _context.Skills.AsNoTracking();
        }

        public async Task<Skill?> GetByIdAsync(long id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
