using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AdminUserRepository(AppDbContext context) : IAdminUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(AdminUser adminUser)
        {
            await _context.AdminUsers.AddAsync(adminUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AdminUser adminUser)
        {
            _context.AdminUsers.Remove(adminUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AdminUser>> GetAllAsync()
        {
            return await _context.AdminUsers.ToListAsync();
        }

        public async Task<AdminUser?> GetByIdAsync(long id)
        {
            return await _context.AdminUsers.FindAsync(id);
        }

        public async Task UpdateAsync(AdminUser adminUser)
        {
            _context.AdminUsers.Update(adminUser);
            await _context.SaveChangesAsync();
        }
    }
}
