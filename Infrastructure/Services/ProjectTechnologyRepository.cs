using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProjectTechnologyRepository(AppDbContext context) : IProjectTechnologyRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(ProjectTechnology projectTechnology)
        {
            await _context.ProjectTechnologies.AddAsync(projectTechnology);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProjectTechnology projectTechnology)
        {
            _context.ProjectTechnologies.Remove(projectTechnology);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProjectTechnology>> GetAllAsync()
        {
            return await _context.ProjectTechnologies.ToListAsync();
        }

        public async Task<List<ProjectTechnology>> GetAllByProjectIdAsync(long projectId)
        {
            return await _context.ProjectTechnologies
                .Where(pt => pt.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<ProjectTechnology?> GetByIdAsync(long id)
        {
            return await _context.ProjectTechnologies
                .FirstOrDefaultAsync(pt => pt.Id == id);
        }

        public async Task UpdateAsync(ProjectTechnology projectTechnology)
        {
            _context.ProjectTechnologies.Update(projectTechnology);
            await _context.SaveChangesAsync();
        }
    }
}
