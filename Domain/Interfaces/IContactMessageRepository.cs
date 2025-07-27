using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable

namespace Domain.Interfaces
{
    public interface IContactMessageRepository
    {
        Task<ContactMessage?> GetByIdAsync(long id);
        Task<List<ContactMessage>> GetAllAsync();
        Task AddAsync(ContactMessage contactMessage);
        Task UpdateAsync(ContactMessage contactMessage);
        Task DeleteAsync(ContactMessage contactMessage);
    }
}
