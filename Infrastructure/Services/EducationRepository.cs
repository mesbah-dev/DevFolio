using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EducationRepository(AppDbContext context) : IEducationRepository
    {
        private readonly AppDbContext _context = context;
        public async Task AddAsync(Education education)
        {
            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Education education)
        {
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Education>> GetAllAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education?> GetByIdAsync(long id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task UpdateAsync(Education education)
        {
            _context.Educations.Update(education);
            await _context.SaveChangesAsync();
        }
    }
}
