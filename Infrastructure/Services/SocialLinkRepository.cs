using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SocialLinkRepository(AppDbContext context) : ISocialLinkRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(SocialLink socialLink)
        {
            await _context.SocialLinks.AddAsync(socialLink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SocialLink socialLink)
        {
            _context.SocialLinks.Remove(socialLink);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SocialLink>> GetAllAsync()
        {
            return await _context.SocialLinks.ToListAsync();
        }

        public async Task<SocialLink?> GetByIdAsync(long id)
        {
            return await _context.SocialLinks.FindAsync(id);
        }

        public async Task UpdateAsync(SocialLink socialLink)
        {
            _context.SocialLinks.Update(socialLink);
            await _context.SaveChangesAsync();
        }
    }
}
