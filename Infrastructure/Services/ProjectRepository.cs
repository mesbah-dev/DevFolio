using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProjectRepository(AppDbContext context) : IProjectRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Project> GetAll()
        {
            return _context.Projects
                .Include(p => p.Technologies)
                .AsNoTracking();
        }

        public async Task<Project?> GetByIdAsync(long id)
        {
            return await _context.Projects.FindAsync(id);
               
        }

        public async Task<Project?> GetByIdWithTechnologiesAsync(long id)
        {
            return await _context.Projects
                           .Include(p => p.Technologies)
                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
