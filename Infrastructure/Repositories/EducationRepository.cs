using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
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

        public IQueryable<Education> GetAll()
        {
            return _context.Educations.AsNoTracking();
        }

        public async Task<Education?> GetByIdAsync(long id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
