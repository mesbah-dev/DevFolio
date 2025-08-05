using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TechnologyRepository(AppDbContext context) : ITechnologyRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Technology technology)
        {
            await _context.Technologies.AddAsync(technology);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Technology technology)
        {
            technology.Deleted = true;
            await _context.SaveChangesAsync();
        }

        public IQueryable<Technology> GetAll()
        {
            return _context.Technologies
                .Where(p => !p.Deleted);
        }

        public async Task<Technology?> GetByIdAsync(long id)
        {
            return await _context.Technologies
                .FirstOrDefaultAsync(p => !p.Deleted);
        }

        public async Task<List<Technology>> GetByIdsAsync(List<long> ids)
        {
            return await _context.Technologies
                .Where(t => ids.Contains(t.Id) && t.IsActive && !t.Deleted)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
