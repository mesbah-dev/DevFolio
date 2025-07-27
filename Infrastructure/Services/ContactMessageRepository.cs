using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ContactMessageRepository(AppDbContext context) : IContactMessageRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(ContactMessage contactMessage)
        {
            await _context.ContactMessages.AddAsync(contactMessage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ContactMessage contactMessage)
        {
            _context.ContactMessages.Remove(contactMessage);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContactMessage>> GetAllAsync()
        {
            return await _context.ContactMessages.ToListAsync();
        }

        public async Task<ContactMessage?> GetByIdAsync(long id)
        {
            return await _context.ContactMessages.FindAsync(id);
        }

        public async Task UpdateAsync(ContactMessage contactMessage)
        {
            _context.ContactMessages.Update(contactMessage);
            await _context.SaveChangesAsync();
        }
    }
}
