using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ExperienceRepository(AppDbContext context) : IExperienceRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Experience experience)
        {
            await _context.Experiences.AddAsync(experience);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Experience experience)
        {
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Experience>> GetAllAsync()
        {
            return await _context.Experiences.ToListAsync();
        }

        public async Task<Experience?> GetByIdAsync(long id)
        {
            return await _context.Experiences.FindAsync(id);
        }

        public async Task UpdateAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
            await _context.SaveChangesAsync();
        }
    }
}
