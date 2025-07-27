using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SiteSettingRepository(AppDbContext context) : ISiteSettingRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(SiteSetting siteSetting)
        {
            await _context.SiteSettings.AddAsync(siteSetting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SiteSetting siteSetting)
        {
            _context.SiteSettings.Remove(siteSetting);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SiteSetting>> GetAllAsync()
        {
            return await _context.SiteSettings.ToListAsync();
        }

        public async Task<SiteSetting?> GetByIdAsync(long id)
        {
            return await _context.SiteSettings.FindAsync(id);
        }

        public async Task UpdateAsync(SiteSetting siteSetting)
        {
            _context.SiteSettings.Update(siteSetting);
            await _context.SaveChangesAsync();
        }
    }
}
