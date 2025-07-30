using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            _context.Technologies.Remove(technology);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Technology>> GetAllAsync()
        {
            return await _context.Technologies
                .Include(p => p.Projects).ToListAsync();
        }

        public async Task<Technology?> GetByIdAsync(long id)
        {
            return await _context.Technologies
                .Include(p => p.Projects)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Technology technology)
        {
            _context.Technologies.Update(technology);
            await _context.SaveChangesAsync();
        }
    }
}
