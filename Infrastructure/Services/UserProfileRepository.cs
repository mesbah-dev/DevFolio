using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserProfileRepository(AppDbContext context) : IUserProfileRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();
        }

        public IQueryable<UserProfile> GetAll()
        {
            return _context.UserProfiles.AsNoTracking();
        }

        public async Task<UserProfile?> GetByIdAsync(long id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task UpdateAsync(UserProfile userProfile)
        {
            await _context.SaveChangesAsync();
        }
    }
}
